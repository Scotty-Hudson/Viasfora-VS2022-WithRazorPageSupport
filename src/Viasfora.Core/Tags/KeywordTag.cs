﻿using System;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Text.Classification;

namespace Winterdom.Viasfora.Tags {
  public class KeywordTag : IClassificationTag {
    public IClassificationType ClassificationType { get; private set; }
    public KeywordTag(IClassificationType classification) {
      this.ClassificationType = classification;
    }
  }
}
