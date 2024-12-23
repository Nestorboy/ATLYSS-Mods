﻿using Nessie.ATLYSS.EasySettings.UIElements;
using UnityEngine;
using UnityEngine.Events;

namespace Nessie.ATLYSS.EasySettings;

public static class Settings
{
    private const string CREATE_TAB_NOTE = "Sorry, but this mod currently doesn't have any way to handle overflowing the tabs container, so the functions to create more tabs will have to be inaccessible for now.";

    public static SettingsTab ModTab { get; } = new();

    /// <summary>
    /// Invoked whenever the EasySettings system has been initialized. The system depends on the SettingsManager which is initialized in Start, so it has to wait on that for now.
    /// </summary>
    public static UnityEvent OnInitialized { get; } = new();

    /// <summary>
    /// A callback for whenever the user presses the "Cancel" button.
    /// </summary>
    public static UnityEvent OnCancelSettings { get; } = new();

    /// <summary>
    /// A callback which is invoked whenever the user presses the "Apply" button. Useful for finalizing and saving settings.
    /// </summary>
    public static UnityEvent OnApplySettings { get; } = new();

    /// <summary>
    /// A callback for when the settings menu is closed, this includes when the user presses "Cancel" or "Apply".
    /// </summary>
    public static UnityEvent OnCloseSettings { get; } = new();

    internal static int ModTabIndex { get; set; }

    internal static SettingsTab AddTab(string label)
    {
        SettingsTab tab = new SettingsTab
        {
            
        };

        return tab;
    }
    
    internal static AtlyssTabButton AddTabButton(string label)
    {
        SettingsManager manager = SettingsManager._current;
        Transform tabsContainer = Utility.FindTabsContainer(manager);

        AtlyssTabButton tab = TemplateManager.CreateTabButton((RectTransform)tabsContainer);
        tab.Label.text = label;
        tab.Root.gameObject.SetActive(true);

        return tab;
    }
}