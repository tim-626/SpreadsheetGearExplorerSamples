﻿/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SharedSamples;
using SpreadsheetGear.Windows.Controls;

namespace WPFExplorer
{
    /// <summary>
    /// Simple wrapper around the <see cref="WorkbookView"/> that implements <see cref="IWorkbookView"/> and is used by most <see cref="SharedWindowsSample"/> samples.
    /// </summary>
    public class WpfWorkbookView : WorkbookView, IWorkbookView { }
}
