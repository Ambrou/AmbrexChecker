﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AmbrexCheckerBDD.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ChargementDeFichierAmbrexFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ChargermentFichiersAmbrex.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "Chargement de fichier ambrex", "En tant qu’utilisateur d’AGEX\r\nAfin de comparer deux niveaux d\'exigence\r\nJe veux " +
                    "charger les exigences venant d\'un fichier", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Chargement de fichier ambrex")))
            {
                AmbrexCheckerBDD.Features.ChargementDeFichierAmbrexFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Chargement d\'exigence amont")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Chargement de fichier ambrex")]
        public virtual void ChargementDExigenceAmont()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Chargement d\'exigence amont", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("le fichier ESG.agex bien formé, contenant les exigences amonts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Soit ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ligne exigence"});
            table1.AddRow(new string[] {
                        "ReqID=ESG-001"});
            table1.AddRow(new string[] {
                        "ReqID=ESG-002"});
#line 10
 testRunner.And("il contient les lignes suivantes, chacune une fois seulement", ((string)(null)), table1, "Et ");
#line 14
 testRunner.And("il ne contient pas d\'autre ligne commençant par \"ReqID=\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 15
 testRunner.When("je charge le fichier d\'exigence amont en mémoire", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ReqID"});
            table2.AddRow(new string[] {
                        "ESG-001"});
            table2.AddRow(new string[] {
                        "ESG-002"});
#line 16
 testRunner.Then("la liste des exigences amonts est:", ((string)(null)), table2, "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Chargement d\'exigence aval")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Chargement de fichier ambrex")]
        public virtual void ChargementDExigenceAval()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Chargement d\'exigence aval", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("le fichier ESD.agex bien formé, contenant les exigences avales", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Soit ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ReqID",
                        "Amont"});
            table3.AddRow(new string[] {
                        "ReqID=ESD-001",
                        "Exigence(s)-Amont= ESG-001 (P)"});
            table3.AddRow(new string[] {
                        "ReqID=ESD-002",
                        "Exigence(s)-Amont= ESG-001 (P)"});
            table3.AddRow(new string[] {
                        "ReqID=ESD-003",
                        "Exigence(s)-Amont= ESG-001 (P)"});
            table3.AddRow(new string[] {
                        "ReqID=ESD-004",
                        "Exigence(s)-Amont= ESG-001 (P)  ESG-002 (T)"});
#line 23
 testRunner.And("il contient les informations suivantes, chacune étant une ligne présente une fois" +
                    " seulement au sein d\'un bloc \"REQUIREMENT\":", ((string)(null)), table3, "Et ");
#line 29
 testRunner.And("il ne contient pas d\'autre informations d\'exigence", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 30
 testRunner.When("je charge le fichier d\'exigence aval en mémoire", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ReqID",
                        "Parent"});
            table4.AddRow(new string[] {
                        "ESD-001",
                        "ESG-001"});
            table4.AddRow(new string[] {
                        "ESD-002",
                        "ESG-001"});
            table4.AddRow(new string[] {
                        "ESD-003",
                        "ESG-001"});
            table4.AddRow(new string[] {
                        "ESD-004",
                        "ESG-001 ESG-002"});
#line 31
 testRunner.Then("la liste des exigences avales est:", ((string)(null)), table4, "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion