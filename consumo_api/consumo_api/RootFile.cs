using System;
using System.Collections.Generic;
using System.Text;

namespace consumo_api
{
    class RootFile
    {
        public int Count { get; set; }
        public List<ProjectTFS> Value { get; set; }
    }

    class ProjectTFS
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
        public int Revision { get; set; }
        public string Visibility { get; set; }
    }
}
