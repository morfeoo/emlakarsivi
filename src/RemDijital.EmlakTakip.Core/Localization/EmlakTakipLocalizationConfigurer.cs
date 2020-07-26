using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace RemDijital.EmlakTakip.Localization
{
    public static class EmlakTakipLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(EmlakTakipConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(EmlakTakipLocalizationConfigurer).GetAssembly(),
                        "RemDijital.EmlakTakip.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
