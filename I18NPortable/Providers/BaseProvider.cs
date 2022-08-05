using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace I18NPortable.Providers
{
    public abstract class BaseProvider : ILocaleProvider
    {
        protected readonly Dictionary<string, string> _locales = new Dictionary<string, string>();
        protected Action<string> _logger;

        public BaseProvider()
        {
        }

        public virtual ILocaleProvider SetLogger(Action<string> logger)
        {
            _logger = logger;
            return this;
        }

        public virtual IEnumerable<Tuple<string, string>> GetAvailableLocales()
        {
            return _locales.Select(x =>
            {
                var extension = x.Value.Substring(x.Value.LastIndexOf('.'));
                return new Tuple<string, string>(x.Key, extension);
            });
        }

        public abstract Stream GetLocaleStream(string locale);

        public abstract ILocaleProvider Init();

        public virtual void Dispose()
        {
            _locales.Clear();
            _logger = null;
        }

       
    }
}
