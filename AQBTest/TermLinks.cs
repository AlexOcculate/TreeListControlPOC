using System;
using System.Collections.Generic;
using System.Linq;

namespace AQBTest
{
   public class TermLinks
   {
      /*
      - Top Term / Preferred Term / Non-Preferred Term
      - Annotation:
          - - SN[]
          - - UN[] - Usage Note
          - - DN[] - Definition Note
          - - HN[] - History Note

      - Variations:  (Spelling / Meaning / Pronunciation)
          - - Singular / Plural / Collective / Diminutive / Augmentative / Superlative
          - - Part-of-Speech
          - - Typographic[] (Error/Typo/Spelling)
          - - Lexical[]
          - - Syntactical[]
          - - Abbreviation[]
          - - Acronymous/Initialism[]

      - Equivalency: (Spelling / Meaning / Pronunciation)
          - - USE/SEE/PT <---> UF
              - Preferred Term <---> Non-preferred Term
          - - SYN/SY - Synonym
          - - QSYN - Quasi-Synonym
          - - ANT - Antonym

      - PolyHierarchy / Hierarchy:
          - - BT  <---> NT
          - - BTWP <---> NTWP (Partitive: Whole-Part)
          - - BTGS <---> NTGS (..Generic: Generic-Specialised)
          - - BTCI <---> NTCI (.Instance: Narrow-is-a-Example-or-Instance)
          - - BTCC <---> NTCC (.Compound: Narrow is a Component of the Compound)
          - - BTTC <---> NTTC (....Thing: Thing-Characteristic)
          - - BTDV <---> NTDV (DataValue: Data-Value) ??? is it not the Class-Instance???

      - Associative:

          - - RT (Neither Hierarchical nor Equivalent but there a relation...)
              - Terms belonging to the Same Categories
              - Terms belonging to Different Categories
                  - Whole-Part Associative Relationship
                  - ...

      - Grouping:
          - - MT - MiniThesaurus
      */

      #region --- Preferred Term: PT/USE + UF ---
      private List<TermLinks> _pt;
      private List<TermLinks> _uf;
      #endregion
      //
      #region --- Equivalency Term: SYN/QSYN/ANT ---
      private List<TermLinks> _syn;
      private List<TermLinks> _qsyn;
      private List<TermLinks> _ant;
      #endregion
      //
      #region --- Associative Term: RT ---
      private List<TermLinks> _rt;
      #endregion
      //
      #region --- Broad Term: BTP/BTG/BTI/BTC ---
      // [Partitive: Whole-Part]
      // Narrow Term is a part of the Whole Broad Term.
      // Car and Tyre
      private List<TermLinks> _btp;
      // [Generic+Specialised]:
      // Narrow Term is a Specialisation of the Generic Broad Term.
      // Customer and Business Customer
      private List<TermLinks> _btg;
      // [Class+Instance]:
      // Narrow Term is an Example-or-Instance of the Class Broad Term.
      // Customer and 'Alex Silva'
      private List<TermLinks> _bti;
      // [Compound+Component]:
      // Narrow Term is a Component of the Compound Broad Term.
      // Water and Hydrogen
      private List<TermLinks> _btc;
      #endregion
      //
      #region --- Narrow Term: NTP/NTG/NTI/NTC ---
      // [Partitive: Whole-Part]
      // Narrow Term is a part of the Whole Broad Term.
      private List<TermLinks> _ntp;
      // [Generic+Specialised]:
      // Narrow Term is a Specialisation of the Generic Broad Term.
      private List<TermLinks> _ntg;
      // [Class+Instance]:
      // Narrow Term is an Example-or-Instance of the Class Broad Term.
      private List<TermLinks> _nti;
      // [Compound+Component]:
      // Narrow Term is a Component of the Compound Broad Term.
      private List<TermLinks> _ntc;
      #endregion
      //
      #region --- Grouping Term: MT ---
      private List<TermLinks> _mt;
      #endregion
      //
      #region --- Annotation: SN/HN ---
      private List<String> _sn;
      private List<String> _hn;
      private List<String> _an;
      #endregion
      //
      //
      // serilization
      // deserialization
      //
      // CRUD fire term's relationship
      // Search Terms and Relationship
      // Report, Statistics and Charts.
      // Import and Export
      // Document
      // Diagram
      // Templates (FreeMarker/Velocity)
      // Global Properties / Environ Vars
      // Database Connection
      //
   }
}
