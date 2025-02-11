﻿using System.Windows.Controls;

namespace WPFExplorer.Samples.WorkbookView.Reporting
{
    public partial class WorkbookConsolidationSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Windows.Samples.Reporting.WorkbookConsolidationSample Sample { get; private set; }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView.  Disposal of 
            /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
            /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
            /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
            /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
            DisposalManager.ResetWorkbookView(workbookView, false);

            // Get selected region and run the sample.
            string selectedRegion = (string)((RadioButton)e.Source).Tag;
            Sample.RunReport(workbookView, selectedRegion);
        }

        #region Sample Initialization Code
        public WorkbookConsolidationSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Windows.Samples.Reporting.WorkbookConsolidationSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
