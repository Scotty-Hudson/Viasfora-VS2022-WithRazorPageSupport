﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace Winterdom.Viasfora.Outlining {
  public interface IUserOutlining {
    IEnumerable<SnapshotSpan> GetTags(NormalizedSnapshotSpanCollection spans);
    void Add(SnapshotSpan span);
    void RemoveAt(SnapshotPoint point);
    bool IsInOutliningRegion(SnapshotPoint point);
    bool HasUserOutlines();
    void RemoveAll(ITextSnapshot snapshot);
  }

  public interface IOutliningManager {
    ITagger<IOutliningRegionTag> GetOutliningTagger();
    ITagger<IGlyphTag> GetGlyphTagger();
  }
}
