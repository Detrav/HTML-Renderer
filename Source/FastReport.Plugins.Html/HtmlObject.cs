using FastReport.Code;
using FastReport.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.Core;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace FastReport.Plugins.Html
{
    public class HtmlObject : FastReport.HtmlObject
    {
        HtmlContainerInt htmlContainer;

        public override void Draw(FRPaintEventArgs e)
        {
            if (IsDesigning)
            {
                if (IsAncestor)
                    e.Graphics.DrawImage(Res.GetImage(99), (int)(AbsRight * e.ScaleX - 9), (int)(AbsTop * e.ScaleY + 2));
            }
            DrawBackground(e);
            DrawHtml(e);
            DrawMarkers(e);
            Border.Draw(e, new RectangleF(AbsLeft, AbsTop, Width, Height));
            DrawDesign(e);
        }

        private void DrawHtml(FRPaintEventArgs e)
        {
            using (var container = new HtmlContainer())
            {
                var state = e.Graphics.Save();
                try
                {
                    
                    e.Graphics.ScaleTransform(e.ScaleX, e.ScaleY);
                    container.Location = new PointF(AbsLeft , AbsTop );
                    container.MaxSize = new SizeF(Width , Height );
                    container.AvoidAsyncImagesLoading = true;
                    container.AvoidImagesLateLoading = true;
                    container.UseGdiPlusTextRendering = true;



                    //if (stylesheetLoad != null)
                    //    container.StylesheetLoad += stylesheetLoad;
                    //if (imageLoad != null)
                    //    container.ImageLoad += imageLoad;

                    container.SetHtml(Text, null /*cssData*/);
                    container.PerformLayout(e.Graphics);
                    container.PerformPaint(e.Graphics);

                    //actualSize = container.ActualSize;
                }
                finally
                {
                    e.Graphics.Restore(state);
                }
            }
        }

        private void DrawDesign(FRPaintEventArgs e)
        {
            //DrawDragAcceptFrame(e, Color.Silver);
        }


        public HtmlObject()
        {
            
        }
    }
}
