﻿using System;
using System.ComponentModel.Composition;
using Winterdom.Viasfora.Languages.BraceScanners;
using Winterdom.Viasfora.Rainbow;
using Winterdom.Viasfora.Settings;

namespace Winterdom.Viasfora.Languages {
  [Export(typeof(ILanguage))]
  class TypeScript : CBasedLanguage, ILanguage {
    public const String ContentType = "TypeScript";

    protected override String[] SupportedContentTypes
      => new String[] { ContentType };
    public ILanguageSettings Settings { get; private set; }

    [ImportingConstructor]
    public TypeScript(ITypedSettingsStore store) {
      this.Settings = new TypeScriptSettings(store);
    }

    protected override IBraceScanner NewBraceScanner()
      => new JScriptBraceScanner();
  }

  class TypeScriptSettings : LanguageSettings {
    protected override String[] ControlFlowDefaults => new String[] {
       "if", "else", "while", "do", "for", "switch",
       "break", "continue", "return", "throw"
      };
    protected override String[] LinqDefaults => new String[] {
       "in", "with"
      };
    protected override String[] VisibilityDefaults => new String[] {
       "export", "public", "private"
      };

    public TypeScriptSettings(ITypedSettingsStore store)
      : base (Langs.TypeScript, store) {
    }
  }
}
