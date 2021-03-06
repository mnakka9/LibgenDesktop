﻿using System;
using System.Collections.Generic;
using System.Linq;
using LibgenDesktop.Models.Localization.Localizators;

namespace LibgenDesktop.Models.Localization
{
    internal class Language
    {
        private readonly List<Translation> translations;
        private MainWindowLocalizator mainWindow;
        private DatabaseWindowLocalizator databaseWindow;
        private SearchTabLocalizator searchTab;
        private NonFictionSearchResultsTabLocalizator nonFictionSearchResultsTab;
        private FictionSearchResultsTabLocalizator fictionSearchResultsTab;
        private SciMagSearchResultsTabLocalizator sciMagSearchResultsTab;
        private CommonDetailsTabLocalizator commonDetailsTab;
        private NonFictionDetailsTabLocalizator nonFictionDetailsTab;
        private FictionDetailsTabLocalizator fictionDetailsTab;
        private SciMagDetailsTabLocalizator sciMagDetailsTab;
        private ImportLocalizator import;
        private ExportPanelLocalizator exportPanel;
        private NonFictionExporterLocalizator nonFictionExporter;
        private FictionExporterLocalizator fictionExporter;
        private SciMagExporterLocalizator sciMagExporter;
        private SynchronizationLocalizator synchronization;
        private DownloadManagerLocalizator downloadManager;
        private ApplicationUpdateLocalizator applicationUpdate;
        private SettingsWindowLocalizator settings;
        private MessageBoxLocalizator messageBox;
        private ErrorWindowLocalizator errorWindow;

        public Language(List<Translation> prioritizedTranslationList)
        {
            translations = prioritizedTranslationList;
            mainWindow = null;
            databaseWindow = null;
            searchTab = null;
            nonFictionSearchResultsTab = null;
            fictionSearchResultsTab = null;
            sciMagSearchResultsTab = null;
            commonDetailsTab = null;
            nonFictionDetailsTab = null;
            fictionDetailsTab = null;
            sciMagDetailsTab = null;
            import = null;
            exportPanel = null;
            nonFictionExporter = null;
            fictionExporter = null;
            sciMagExporter = null;
            synchronization = null;
            downloadManager = null;
            applicationUpdate = null;
            settings = null;
            messageBox = null;
            errorWindow = null;
            Translation mainTranslation = prioritizedTranslationList.First();
            Name = mainTranslation.General?.Name?.Trim() ?? String.Empty;
            LocalizedName = mainTranslation.General?.LocalizedName?.Trim() ?? String.Empty;
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(LocalizedName))
            {
                DisplayName = $"{Name} ({LocalizedName})";
            }
            else
            {
                DisplayName = "Error";
            }
            CultureCode = mainTranslation.General?.CultureCode?.Trim() ?? String.Empty;
            Formatter = new LanguageFormatter(prioritizedTranslationList);
        }

        public string Name { get; }
        public string LocalizedName { get; }
        public string DisplayName { get; }
        public string CultureCode { get; }
        public LanguageFormatter Formatter { get; }

        public MainWindowLocalizator MainWindow => mainWindow ?? (mainWindow = new MainWindowLocalizator(translations, Formatter));

        public DatabaseWindowLocalizator DatabaseWindow => databaseWindow ?? (databaseWindow = new DatabaseWindowLocalizator(translations, Formatter));

        public SearchTabLocalizator SearchTab => searchTab ?? (searchTab = new SearchTabLocalizator(translations, Formatter));

        public NonFictionSearchResultsTabLocalizator NonFictionSearchResultsTab =>
            nonFictionSearchResultsTab ?? (nonFictionSearchResultsTab = new NonFictionSearchResultsTabLocalizator(translations, Formatter));

        public FictionSearchResultsTabLocalizator FictionSearchResultsTab =>
            fictionSearchResultsTab ?? (fictionSearchResultsTab = new FictionSearchResultsTabLocalizator(translations, Formatter));

        public SciMagSearchResultsTabLocalizator SciMagSearchResultsTab =>
            sciMagSearchResultsTab ?? (sciMagSearchResultsTab = new SciMagSearchResultsTabLocalizator(translations, Formatter));

        public CommonDetailsTabLocalizator CommonDetailsTab =>
            commonDetailsTab ?? (commonDetailsTab = new CommonDetailsTabLocalizator(translations, Formatter));

        public NonFictionDetailsTabLocalizator NonFictionDetailsTab =>
            nonFictionDetailsTab ?? (nonFictionDetailsTab = new NonFictionDetailsTabLocalizator(translations, Formatter));

        public FictionDetailsTabLocalizator FictionDetailsTab =>
            fictionDetailsTab ?? (fictionDetailsTab = new FictionDetailsTabLocalizator(translations, Formatter));

        public SciMagDetailsTabLocalizator SciMagDetailsTab =>
            sciMagDetailsTab ?? (sciMagDetailsTab = new SciMagDetailsTabLocalizator(translations, Formatter));

        public ImportLocalizator Import => import ?? (import = new ImportLocalizator(translations, Formatter));

        public ExportPanelLocalizator ExportPanel => exportPanel ?? (exportPanel = new ExportPanelLocalizator(translations, Formatter));

        public NonFictionExporterLocalizator NonFictionExporter =>
            nonFictionExporter ?? (nonFictionExporter = new NonFictionExporterLocalizator(translations, Formatter));

        public FictionExporterLocalizator FictionExporter => fictionExporter ?? (fictionExporter = new FictionExporterLocalizator(translations, Formatter));

        public SciMagExporterLocalizator SciMagExporter => sciMagExporter ?? (sciMagExporter = new SciMagExporterLocalizator(translations, Formatter));

        public SynchronizationLocalizator Synchronization => synchronization ?? (synchronization = new SynchronizationLocalizator(translations, Formatter));

        public DownloadManagerLocalizator DownloadManager => downloadManager ?? (downloadManager = new DownloadManagerLocalizator(translations, Formatter));

        public ApplicationUpdateLocalizator ApplicationUpdate =>
            applicationUpdate ?? (applicationUpdate = new ApplicationUpdateLocalizator(translations, Formatter));

        public SettingsWindowLocalizator Settings => settings ?? (settings = new SettingsWindowLocalizator(translations, Formatter));

        public MessageBoxLocalizator MessageBox => messageBox ?? (messageBox = new MessageBoxLocalizator(translations, Formatter));

        public ErrorWindowLocalizator ErrorWindow => errorWindow ?? (errorWindow = new ErrorWindowLocalizator(translations, Formatter));
    }
}
