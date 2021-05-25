namespace WindowsFormsExplorer.Samples.Printing
{
    public partial class PageBreaksSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Printing.PageBreaksSample Sample { get; private set; }

        private void buttonPrintPreview_Click(object sender, System.EventArgs e)
        {
            // Run the sample.
            Sample.Print(workbookView, radioButtonPageBreaksUsed.Checked);
        }


        #region Sample Initialization Code
        public PageBreaksSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            Sample = new SamplesLibrary.Samples.Printing.PageBreaksSample();
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
