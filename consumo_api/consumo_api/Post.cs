using System;
using System.Collections.Generic;
using System.Text;

namespace consumo_api
{
    class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return $"{UserId}, {Id},\n=================\n{Title},\n=================\n{Body}";
        }
    }
}
