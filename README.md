# Checkout

The following is a solution the coding Kata described here http://codekata.com/kata/kata09-back-to-the-checkout/

Before running the solution, please rebuild it to ensure the Rule assemblies are built. This is due to the use of reflection to dynamically load the rule assemblies in. The Checkout project should be the startup project.

My implementation of the SKU uses reflection to load different rules that are then implemented in a rules/strategy type pattern. I have implemented two types of rules:

 - The first is the one asked for in the problem. This also takes into account when the rule could be applied multiple times. For example if the rule is 2 for £10, and you have four eligible items the rule will be applied twice to give a result for 4 for £20
 - The second is a catch all rule that sums the total of any units not included in the first rule.

Different rule types can be easily added. They can also be expanded to include non SKU rules, for example 10% discount on all order over a certain amount. Rules also have a processing order, so the rules can be applied in the correct order. 

The rules are loaded from a Fake data source, but it has been implemented so you can easily use a different data source, for example to a database or web service.

Reflection would allow new Rule assemblies to be added at runtime, without having to rebuild the application. They can then be configured via a datasource.

Using reflection can have a performance hit, but the loading of the dlls that implement each rule could be done differently or alternatively use a caching mechanism.

Areas for improvement:
 - SKU units using decimal, in case we are buying different types of units (for example by weight).
 - Better error handling.
 - Further testing in particular edge cases.
 - Additional unit tests.
 - Logging
 - Could add to/from dates on rules.
 - Implement an alternative to reflection, for example MEF.
