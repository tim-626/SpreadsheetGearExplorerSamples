﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SamplesLibrary.Engine.Samples.Shapes
{
    public class PictureSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create local variables to the active worksheet and its window info.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;

            // Get the full path to a PNG image file.
            string imagePath = Helpers.GetFullOutputFolderPath(@"Files\Engine\SG-Picture.png");

            // Get the width and height of the picture in pixels and convert to
            // points for use in the call to AddPicture.  This step is only
            // necessary if the actual picture size is to be used and that size
            // is unknown.  Another option is to calculate the width and height 
            // in row and column coordinates in the same manner as the left 
            // and top are calculated in the code below.
            double width;
            double height;
            // Note we are using a 3rd party imaging library (SkiaSharp) here to open a PNG
            // and get its measurements.  If you are on Windows, you could instead use the
            // System.Drawing.Image class to get this information.  We do not do so here
            // so that these Engine samples can be used in non-Windows environments such as
            // Linux and MacOS.
            using (var image = SkiaSharp.SKImage.FromEncodedData(imagePath))
            {
                width = image.Width * 72.0 / 96.0;
                height = image.Height * 72.0 / 96.0;
            }

            // Calculate the left and top coordinates of the picture by converting 
            // row and column coordinates to points.  Use fractional values to 
            // get coordinates anywhere in between row and column boundaries.
            double left = windowInfo.ColumnToPoints(0.25);
            double top = windowInfo.RowToPoints(1.5);

            // Add the picture from the file's bytes and use the calculated bounds.
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
            SpreadsheetGear.Shapes.IShape shape =
                worksheet.Shapes.AddPicture(imageBytes, left, top, width, height);

            // Remove the border around the picture shape.
            shape.Line.Visible = false;

            // Select the picture.
            shape.Select(true);
        }
    }
}
