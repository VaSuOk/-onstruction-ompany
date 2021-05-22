using System;
using System.Collections.Generic;
using System.Text;

namespace Сonstruction_сompany.View
{
    public enum Stage
    {
        Earthwork,
        Construction,
        Roofing,
        ProcessingInside

    }
    public class Questionnaire
    {
        public uint ID { get; set; }
        public User user { get; set; }
        public Stage stage { get; set; }
        public string Position { get; set; }
        public string RegionOfWork { get; set; }
        public bool activated { get; set; }
        public bool confirmed { get; set; }
    }
}
