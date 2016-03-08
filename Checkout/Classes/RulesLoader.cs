using Contract;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SKUCheckout.Classes
{


    public class RulesLoader : ILoader
    {
        /// <summary>
        /// Load the rules to be used.from the BOL source of the settings is passed in. Then creates an instance of each rule.
        /// </summary>
        /// <param name="ruleBOL">The BOL that is used to load the rule settings</param>
        /// <returns></returns>
        public List<IRule> GetRules(IRulesBOL ruleBOL)
        {
            List<IRule> rules = new List<IRule>();
            
            //Get the rules settings from ther passed in BOL
            List<AssemblyConfigDTO> assemblyList = ruleBOL.GetAssemblyConfig();
            foreach (AssemblyConfigDTO assemblyItem in assemblyList.OrderBy(t => t.ProcessOrder))
            {
                rules.Add(LoadAssembly(assemblyItem));
            }

            //Output rules to console
            DisplayRules(assemblyList);

            return rules;
        }


        static void DisplayRules(List<AssemblyConfigDTO> rules)
        {
            foreach (AssemblyConfigDTO rule in rules)
            {
                Console.WriteLine("Rule: " + rule.Name);
                foreach (var arg in rule.Args)
                {
                    
                    if (arg.ValueDecimal != null)
                        Console.Write(string.Format("{0}:{1},", arg.Name, arg.ValueDecimal));
                    if (arg.ValueInt != null)
                        Console.Write(string.Format("{0}:{1},", arg.Name, arg.ValueInt));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Create an instance using reflection for each rule
        /// </summary>
        /// <param name="assemblyItem">Config settings that contain the DLL path to load each rule</param>
        /// <returns></returns>
        IRule LoadAssembly(AssemblyConfigDTO assemblyItem)
        {

            if (!File.Exists(assemblyItem.FilePath))
                throw new SystemException(string.Format("Report DLL cannot be found: {0}", assemblyItem.FilePath));

            Assembly assembly = Assembly.LoadFrom(assemblyItem.FilePath);
            if (assembly == null)
                throw new SystemException(string.Format("There was a problem load the rule type DLL: {0}", assemblyItem.FilePath));

            Type type = assembly.GetType(assemblyItem.Type);
            if (type == null)
                throw new SystemException(string.Format("Cannot find the rule: {0}", assemblyItem.FilePath));

            //Create a list of arguements to pass into the rulke constructor
            object[] args = new object[assemblyItem.Args.Count];
            int index = 0;
            foreach (ConstructorArgsDTO arg in assemblyItem.Args.OrderBy(t => t.Order))
            {
                //To do - better way of handling different arg types
                if (arg.ValueDecimal != null)
                    args[index] = arg.ValueDecimal.Value;
                else if (arg.ValueInt != null)
                    args[index] = arg.ValueInt.Value;
                else
                    args[index] = arg.ValueString;

                index++;
            }

            object instanceOfRule;
            instanceOfRule = Activator.CreateInstance(type, args);

            //Create instance of the BOL
            if (instanceOfRule == null)
                throw new SystemException(string.Format("Error creating instance of rule type: {0}", type));

            //Check rule implements IRule
            IRule rule = ((IRule)instanceOfRule);
            if (rule == null)
                throw new SystemException(string.Format("Rule does not implement IRule: {0}", type));

            //Check method exists in BOL
            MethodInfo method = instanceOfRule.GetType().GetMethod("Calculate");
            if (method == null)
                throw new SystemException(string.Format("Calculate method not found: ", type));

            return rule;
        }

    }
}
