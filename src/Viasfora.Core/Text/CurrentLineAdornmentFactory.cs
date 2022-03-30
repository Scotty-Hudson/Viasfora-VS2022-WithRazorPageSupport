﻿using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace Winterdom.Viasfora.Text {

  [Export(typeof(IWpfTextViewCreationListener))]
  [ContentType(ContentTypes.Text)]
  [TextViewRole(PredefinedTextViewRoles.Editable)]
  internal sealed class CurrentLineAdornmentFactory : IWpfTextViewCreationListener {
    [Import]
    public IClassificationTypeRegistryService ClassificationRegistry { get; set; }
    [Import]
    public IClassificationFormatMapService FormatMapService { get; set; }
    [Import]
    public IVsfSettings Settings { get; set; }

    [Export(typeof(AdornmentLayerDefinition))]
    [Name(Constants.LINE_HIGHLIGHT)]
    [Order(Before = PredefinedAdornmentLayers.Selection)]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    public AdornmentLayerDefinition editorAdornmentLayer = null;

    public void TextViewCreated(IWpfTextView textView) {
      IClassificationType classification =
         ClassificationRegistry.GetClassificationType(Constants.LINE_HIGHLIGHT);
      IClassificationFormatMap map =
         //FormatMapService.GetClassificationFormatMap(FontsAndColorsCategories.TextEditorCategory);
         FormatMapService.GetClassificationFormatMap(textView);
      textView.Properties.GetOrCreateSingletonProperty(
        () => {
          return new CurrentLineAdornment(textView, map, classification, Settings);
        });
    }
  }
}
