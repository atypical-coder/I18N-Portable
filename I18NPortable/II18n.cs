﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace I18NPortable
{
    public interface II18N : INotifyPropertyChanged, IDisposable
    {
        string this[string key] { get; }
        PortableLanguage Language { get; set; }
        string Locale { get; set; }
        List<PortableLanguage> Languages { get; }

        II18N SetNotFoundSymbol(string symbol);
        II18N SetLogger(Action<string> output);
        II18N SetThrowWhenKeyNotFound(bool enabled);
        II18N SetFallbackLocale(string locale);
        II18N SetResourcesFolder(string folderName);
        II18N AddLocaleReader(ILocaleReader reader, string extension);
        II18N AddProvider(ILocaleProvider provider);
        II18N Reload();
        II18N Init(Assembly hostAssembly);

        string GetDefaultLocale();

        string Translate(string key, params object[] args);
        string TranslateOrNull(string key, params object[] args);

        Dictionary<TEnum, string> TranslateEnumToDictionary<TEnum>();
        List<string> TranslateEnumToList<TEnum>();
        List<Tuple<TEnum, string>> TranslateEnumToTupleList<TEnum>();
    }
}