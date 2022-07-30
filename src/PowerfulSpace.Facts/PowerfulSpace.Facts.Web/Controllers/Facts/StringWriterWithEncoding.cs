using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Controllers.Facts
{
    public class StringWriterWithEncoding : StringWriter
    {

        public override Encoding Encoding { get; }

        public StringWriterWithEncoding(Encoding encoding) => Encoding = encoding;

    }
}
