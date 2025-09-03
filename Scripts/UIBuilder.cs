using UnityEngine;
using UnityEngine.UIElements;
using System;

/// <summary>
/// Fluent helper for building and wiring UI Toolkit trees at runtime.
/// Wraps a cloned root <see cref="VisualElement"/> and exposes chainable helpers
/// to set text, images, buttons and callbacks.
/// </summary>
public class UIBuilder
{
    public VisualElement Element => root;
    VisualElement root;

    /// <summary>
    /// Creates a builder that wraps an existing root element.
    /// Prefer <see cref="Instantiate(VisualTreeAsset, VisualElement)"/> to clone from UXML.
    /// </summary>
    /// <param name="root">The root element to wrap.</param>
    public UIBuilder(VisualElement root)
    {
        this.root = root;
    }

    /// <summary>
    /// Clones a UXML asset and optionally adds it to a parent, returning a builder
    /// for fluent configuration.
    /// </summary>
    /// <param name="asset">The UXML to clone.</param>
    /// <param name="parent">Optional parent to attach the cloned root to. If null, a warning is logged.</param>
    /// <returns>A <see cref="UIBuilder"/> wrapping the cloned root element.</returns>
    /// <example>
    /// var modal = UIBuilder.Instantiate(modalUxml, container)
    ///     .SetLabel("text-content", "Hello")
    ///     .SetButton("main-button", "Close", Close);
    /// </example>
    public static UIBuilder Instantiate(VisualTreeAsset asset, VisualElement parent = null)
    {
        var root = asset.CloneTree();
        if (parent == null)
            Debug.LogWarning($"No parent found for '{asset.name}'");
        parent?.Add(root);
        return new UIBuilder(root);
    }

    public UIBuilder SetLabel(string elementName, string text)
    {
        var el = root.Q<Label>(elementName);
        if (el == null) return Warning(elementName);
        el.text = text;
        return this;
    }

    public UIBuilder SetImage(string elementName, Texture2D texture)
    {
        var img = root.Q<Image>(elementName);
        if (img == null) return Warning(elementName);
        img.image = texture;
        return this;
    }

    public UIBuilder SetButton(string elementName, string title, Action callback)
    {
        var btn = root.Q<Button>(elementName);
        if (btn == null) return Warning(elementName);
        btn.text = title;
        btn.clicked += callback;
        return this;
    }

    public UIBuilder OnClick(string elementName, Action callback)
    {
        var btn = root.Q<Button>(elementName);
        if (btn == null) return Warning(elementName);
        btn.clicked += callback;
        return this;
    }

    /// <summary>
    /// Removes the wrapped root element from its parent hierarchy.
    /// </summary>
    public void Remove()
    {
        root.RemoveFromHierarchy();
    }

    /// <summary>
    /// Logs a warning for a missing element and preserves chaining.
    /// </summary>
    UIBuilder Warning(string elementName)
    {
        Debug.LogWarning($"Element '{elementName}' not found.");
        return this;
    }
}
