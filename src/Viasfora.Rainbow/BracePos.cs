﻿using System;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Winterdom.Viasfora.Tags;

namespace Winterdom.Viasfora.Rainbow {
  public struct BracePos {
    private int depth;
    private CharPos charPos;

    public char Brace => this.charPos.Char;
    public int Depth => this.depth;
    public int Position => this.charPos.Position;
    public int State => this.charPos.State;

    public BracePos(char ch, int pos, int depth) {
      this.charPos = new CharPos(ch, pos);
      this.depth = depth;
    }
    public BracePos(CharPos pos, int depth) {
      this.charPos = pos;
      this.depth = depth;
    }

    public ITagSpan<RainbowTag> ToSpan(ITextSnapshot snapshot, IClassificationType type) {
      var span = new SnapshotSpan(snapshot, Position, 1);
      return new TagSpan<RainbowTag>(span, new RainbowTag(type));
    }

    public SnapshotPoint ToPoint(ITextSnapshot snapshot) {
      return new SnapshotPoint(snapshot, Position);
    }

    public CharPos ToCharPos() {
      return this.charPos;
    }

    public override string ToString() {
      return String.Format("'{0}' ({1}) {2}", Brace, Position, Depth);
    }
  }
}
