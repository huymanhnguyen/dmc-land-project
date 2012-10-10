using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMC.GIS.Common
{
    public class LableLayer
    {
        public void ShowLabelLayer(ref MapInfo.Mapping.Map map, string tableName, string columnName,string strLableLayerName, bool lbUnderLine, string strAlignment)
        {
            /* Kiểm tra sự tồn tại lớp có tên là strLableLayerName */
            if (map.Layers.Contains(map.Layers[strLableLayerName]))
            {
                map.Layers.Remove(strLableLayerName);
                /* Nếu lớp có tên là strLableLayerName tồn tại thì đóng lớp đó lại trước khi thực hiện */
                MapInfo.Engine.Session.Current.Catalog.CloseTable(strLableLayerName);
            }

            MapInfo.Mapping.LabelLayer labelLayer = new MapInfo.Mapping.LabelLayer();
            labelLayer.Name = strLableLayerName;
            labelLayer.Alias = strLableLayerName;

            map.Layers.Add(labelLayer);
            // specify the data table marked
            MapInfo.Mapping.LabelSource labelSource = new MapInfo.Mapping.LabelSource(MapInfo.Engine.Session.Current.Catalog.GetTable((tableName)));
            
            labelLayer.Sources.Append (labelSource);

            // specify marking out the field where
            labelSource.DefaultLabelProperties.Caption = columnName;
            // style attributes such as tagging
            labelSource.DefaultLabelProperties.Visibility.Enabled = true;
            labelSource.DefaultLabelProperties.Visibility.VisibleRangeEnabled = true;
            labelSource.DefaultLabelProperties.Visibility.VisibleRange = new MapInfo.Mapping.VisibleRange(1, 500, MapInfo.Geometry.DistanceUnit.Meter);
            labelSource.DefaultLabelProperties.Visibility.AllowDuplicates =  true;
            labelSource.DefaultLabelProperties.Visibility.AllowOutOfView =  true;
            labelSource.DefaultLabelProperties.Visibility.AllowOverlap =  true;
            //labelSource.Maximum = 50;
            labelSource.DefaultLabelProperties.Layout.UseRelativeOrientation = true;
            //labelSource.DefaultLabelProperties.Layout.RelativeOrientation = MapInfo.Text.RelativeOrientation.FollowPath;
            labelSource.DefaultLabelProperties.Layout.Angle = 0; //33.0;
            //labelSource.DefaultLabelProperties.Priority.Major = "index";
            //labelSource.DefaultLabelProperties.Layout.Offset = 7;
            // offset
            labelSource.DefaultLabelProperties.Style.Font.TextEffect = MapInfo.Styles.TextEffect.Box;
            // mark background, BOX for box 
            MapInfo.Styles.Font font = new MapInfo.Styles.Font("Bold", 10);
            if (strAlignment == "TopCenter")
            {
                labelSource.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.TopCenter;           

                font.ForeColor = System.Drawing.Color.DarkBlue;
            }
            else if (strAlignment == "BottomCenter")
            {
                labelSource.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.BottomCenter;
                font.ForeColor = System.Drawing.Color.DarkBlue;
            }
            else if (strAlignment == "LeftCenter")
            {
                labelSource.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.CenterLeft;               
                font = new MapInfo.Styles.Font("Bold", 15);
                font.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                labelSource.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.CenterCenter ;
            }

            
            // Underline
            if (lbUnderLine)
            {
                font.TextDecoration = MapInfo.Styles.TextDecoration.Underline;
            }
            else
            {
                font.TextDecoration = MapInfo.Styles.TextDecoration.None;
            }
            // Bold
            font.FontWeight = MapInfo.Styles.FontWeight.Bold;
            labelSource.DefaultLabelProperties.Style.Font = font;

        }
    }
}
