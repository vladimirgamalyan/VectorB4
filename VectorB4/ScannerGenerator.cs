using System;
using System.Collections.Generic;
using System.Globalization;

namespace VectorB4
{
    public class ScannerGenerator
    {
        public class TapParameters
        {
            public decimal Radius { get; set; }
            public decimal Speed { get; set; }
            public decimal Step { get; set; }
            public decimal Retire { get; set; }
            public AppConfig.OrientationType Orientation { get; set; }
            public string InputOblakoFile { get; set; }
        }

        public List<string> GenerateLines(TapParameters p)
        {
            if (p.Radius <= 0)
                throw new ArgumentException("Radius должен быть больше нуля.");
            if (p.Step <= 0)
                throw new ArgumentException("Step должен быть больше нуля.");

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            var lines = new List<string>();

            lines.Add("(*** scaning ***)");
            lines.Add("M40");
            lines.Add("F" + p.Speed.ToString("0.##", nfi));
            lines.Add("M08");
            lines.Add("(* ustanovite shup u kraya diska i najmite start *)");
            lines.Add("M00");
            lines.Add("G91");

            decimal currentRadius = 0;
            do
            {
                switch (p.Orientation)
                {
                    case AppConfig.OrientationType.Hor:
                        lines.Add("G31X-20");
                        lines.Add("G0X" + p.Retire.ToString("0.##", nfi));
                        lines.Add("G0Y" + p.Step.ToString("0.##", nfi));
                        break;

                    case AppConfig.OrientationType.Ver:
                        lines.Add("G31Y-20");
                        lines.Add("G0Y" + p.Retire.ToString("0.##", nfi));
                        lines.Add("G0X-" + p.Step.ToString("0.##", nfi));
                        break;

                    default:
                        throw new InvalidOperationException("Unknown orientation: " + p.Orientation);
                }

                currentRadius += p.Step;
            }
            while (currentRadius <= p.Radius);

            lines.Add("G90");

            switch (p.Orientation)
            {
                case AppConfig.OrientationType.Hor:
                    lines.Add("G0X0");
                    lines.Add("G0Y0");
                    break;

                case AppConfig.OrientationType.Ver:
                    lines.Add("G0Y0");
                    lines.Add("G0X0");
                    break;
            }

            lines.Add($"(* skanirovanie sohranit kak:\"{p.InputOblakoFile}\" !!! *)");
            lines.Add("M30");

            return lines;
        }
    }
}
