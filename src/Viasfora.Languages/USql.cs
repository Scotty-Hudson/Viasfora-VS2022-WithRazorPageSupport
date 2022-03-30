﻿using System;
using System.ComponentModel.Composition;
using Winterdom.Viasfora.Languages.BraceScanners;
using Winterdom.Viasfora.Languages.Sequences;
using Winterdom.Viasfora.Rainbow;
using Winterdom.Viasfora.Settings;
using Winterdom.Viasfora.Util;

namespace Winterdom.Viasfora.Languages {
  [Export(typeof(ILanguage))]
  public class USql : LanguageInfo, ILanguage {
    protected override String[] SupportedContentTypes {
      get { return new String[] { "U-SQL" }; }
    }

    public ILanguageSettings Settings { get; private set; }

    [ImportingConstructor]
    public USql(ITypedSettingsStore store) {
      this.Settings = new USqlSettings(store);
    }

    protected override IBraceScanner NewBraceScanner() {
      return new USqlBraceScanner();
    }

    public override IStringScanner NewStringScanner(String classificationName, String text) {
      return new CSharpStringScanner(text, classificationName);
    }

    public override bool IsKeywordClassification(String classificationType) {
      return classificationType.EndsWith("keyword", StringComparison.OrdinalIgnoreCase);
    }
  }

  class USqlSettings : LanguageSettings {
    protected override String[] ControlFlowDefaults => EMPTY;
    protected override String[] LinqDefaults => new String[] {
        "select", "extract", "process", "reduce", "combine",
        "produce", "using", "output", "from"
      };
    protected override String[] VisibilityDefaults => new String[] {
        "readonly"
      };

    public USqlSettings(ITypedSettingsStore store)
      : base (Langs.USql, store) {
    }
  }
}
