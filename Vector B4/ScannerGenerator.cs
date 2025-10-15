using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Vector_B4
{
    public class ScannerGenerator
    {
        public class TapParameters
        {
            public string OutputPath { get; set; }
            public decimal Radius { get; set; }
            public decimal Speed { get; set; }
            public decimal Step { get; set; }
            public decimal Retire { get; set; }
            public AppConfig.OrientationType Orientation { get; set; }
            public string InputOblakoFile { get; set; }
        }

        public void Generate(TapParameters p)
        {
            if (string.IsNullOrWhiteSpace(p.OutputPath))
                throw new ArgumentException("OutputPath не задан.");

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            using (var file = new StreamWriter(p.OutputPath, false, Encoding.GetEncoding("Windows-1251")))
            {
                decimal currentRadius = 0;

                file.WriteLine("(*** scaning ***)");
                file.WriteLine("M40");
                file.WriteLine("F" + p.Speed.ToString("0.##", nfi));
                file.WriteLine("M08");
                file.WriteLine("(* ustanovite shup u kraya diska i najmite start *)");
                file.WriteLine("M00");
                file.WriteLine("G91");

                do
                {
                    switch (p.Orientation)
                    {
                        case AppConfig.OrientationType.Hor:
                            file.WriteLine("G31X-20");
                            file.WriteLine("G0X" + p.Retire.ToString("0.##", nfi));
                            file.WriteLine("G0Y" + p.Step.ToString("0.##", nfi));
                            break;

                        case AppConfig.OrientationType.Ver:
                            file.WriteLine("G31Y-20");
                            file.WriteLine("G0Y" + p.Retire.ToString("0.##", nfi));
                            file.WriteLine("G0X-" + p.Step.ToString("0.##", nfi));
                            break;

                        default:
                            throw new InvalidOperationException("Unknown orientation: " + p.Orientation);
                    }

                    currentRadius += p.Step;
                }
                while (currentRadius <= p.Radius);

                file.WriteLine("G90");

                switch (p.Orientation)
                {
                    case AppConfig.OrientationType.Hor:
                        file.WriteLine("G0X0");
                        file.WriteLine("G0Y0");
                        break;

                    case AppConfig.OrientationType.Ver:
                        file.WriteLine("G0Y0");
                        file.WriteLine("G0X0");
                        break;
                }

                file.WriteLine($"(* skanirovanie sohranit kak:\"{p.InputOblakoFile}\" !!! *)");
                file.WriteLine("M30");
            }
        }
    }
}
