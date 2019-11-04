using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Domain.Entities
{
    public class Image : Entity
    {
        public byte[] Source { get; set; }
        public string Header { get; set; }

        public Image(Guid id) : base(id)
        {
            Source = null;
            Header = null;
        }
        public Image(Guid id, byte[] source, string header) : base(id)
        {
            Source = source;
            Header = header;
        }
        private Image()
        {

        }

        public bool Update(byte[] source, string header)
        {
            var updated = false;
            if((Source == null && source != null) || Source != null && source != null && !Source.SequenceEqual(source))
            {
                Source = source;
                updated = true;
            }
            if(Header != header)
            {
                Header = header;
                updated = true;
            }
            return updated;
        }
    }
}
