﻿namespace WPFExplorer.Samples.Calculations
{
    public partial class FormulaEvaluationSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Calculations.FormulaEvaluationSample Sample { get; private set; }

        private void EvaluateFormula()
        {
            try
            {
                labelResult.Content = Sample.EvaluateFormula(textBoxFormula.Text);
            }
            catch (System.Exception exc)
            {
                System.Windows.MessageBox.Show(exc.Message,
                    "SpreadsheetGear", System.Windows.MessageBoxButton.OK);
            }
        }


        private void buttonEvaluate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EvaluateFormula();
        }


        private void listBoxFormulas_SelectionChanged(
            object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var item = listBoxFormulas.SelectedItem as System.Windows.Controls.ListBoxItem;
            textBoxFormula.Text = item.Content.ToString();
            EvaluateFormula();
        }


        #region Sample Initialization Code
        public FormulaEvaluationSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.Calculations.FormulaEvaluationSample();
        }
        #endregion
    }
}
