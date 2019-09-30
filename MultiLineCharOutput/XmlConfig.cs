using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MultiLineCharOutput {
    public class XmlConfig : IDisposable {

        const string filename = "Config.xml";
        XmlDocument doc = null;

        public int CheckNbr { get; set; }
        public int EftNbr { get; set; }

        public XmlConfig() {
            doc = new XmlDocument();
            doc.Load(filename);
            var config = doc.DocumentElement;
            CheckNbr = int.Parse(config.GetElementsByTagName("check")[0].InnerText);
            EftNbr = int.Parse(config.GetElementsByTagName("eft")[0].InnerText);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing) {
            if(!disposedValue) {
                if(disposing) {
                    // TODO: dispose managed state (managed objects).
                    var config = doc.DocumentElement;
                    config.GetElementsByTagName("check")[0].InnerText = CheckNbr.ToString();
                    config.GetElementsByTagName("eft")[0].InnerText = EftNbr.ToString();
                    doc.Save(filename);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~XmlConfig()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
