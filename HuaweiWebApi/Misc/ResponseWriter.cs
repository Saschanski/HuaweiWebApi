using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HuaweiWebApi.Misc
{
    public class ResponseWriter
    {
        private readonly StringBuilder _sb;
        private readonly JsonWriter _writer;
        public ResponseWriter()
        {
            _sb = new StringBuilder();
            var sw = new StringWriter(_sb);
            _writer = new JsonTextWriter(sw)
            {
                Formatting = Formatting.Indented
            };
        }

        public void WriteStart()
        {
            _writer.WriteStartObject();
        }

        public void WriteEnd()
        {
            _writer.WriteEndObject();
        }

        public void WriteItem(string key, string value)
        {
            _writer.WritePropertyName(key);
            _writer.WriteValue(value);
        }

        public void WriteDictionary(string name, Dictionary<string, string> dictionary)
        {
            _writer.WritePropertyName(name);
            _writer.WriteStartArray();
            _writer.WriteStartObject();
            foreach (var item in dictionary)
            {
                _writer.WritePropertyName(item.Key);
                _writer.WriteValue(item.Value);
            }
            _writer.WriteEndObject();
            _writer.WriteEndArray();
        }

        public string GetJsonString()
        {
            return _sb.ToString();
        }
    }
}
