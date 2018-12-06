using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace JsonIssue.Localization
{
    public static class JsonIssueLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(JsonIssueConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(JsonIssueLocalizationConfigurer).GetAssembly(),
                        "JsonIssue.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
