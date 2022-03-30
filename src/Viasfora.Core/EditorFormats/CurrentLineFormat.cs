﻿using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Winterdom.Viasfora.EditorFormats {
  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = Constants.LINE_HIGHLIGHT)]
  [Name(Constants.LINE_HIGHLIGHT)]
  [UserVisible(true)]
  [Order(Before = Priority.Default)]
  sealed class CurrentLineFormat : ClassificationFormatDefinition {
    public CurrentLineFormat() {
      this.DisplayName = "Viasfora Current Line";
      this.ForegroundColor = Colors.LightGray;
      this.ForegroundOpacity = 0.3;
      this.BackgroundOpacity = 0.3;
    }
  }
}
