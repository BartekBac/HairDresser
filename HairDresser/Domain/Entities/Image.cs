using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void SetImageData(byte[] source, string header)
        {
            Source = source;
            Header = header;
        }
    }
}
