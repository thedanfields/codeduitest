using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace AutomationTest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {

        BrowserWindow _browser;
        public CodedUITest1()
        {
        }

        private void PerformTest(Action<HtmlControl> testAction)
        {
            using (BrowserWindow bw = BrowserWindow.Launch(new Uri("http://localhost:3000/")))
            {
                bw.WaitForControlReady();
                testAction(new HtmlControl(bw.CurrentDocumentWindow));
                bw.Close();
            };
        }

        [TestMethod]
        public void FindByAttribute()
        {
            PerformTest((document) =>
            {
                document.SearchProperties.Add(HtmlListItem.PropertyNames.ControlDefinition, "ui-tooltip=\"blerg\"", PropertyExpressionOperator.Contains);
                var matches = document.FindMatchingControls();
                Assert.IsTrue(document.FindMatchingControls().Count == 1);
            });
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
