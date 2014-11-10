﻿using System;
using System.Linq;

namespace Penneo
{
    public class SignatureLine : Entity
    {
        private Signer _signer;

        public SignatureLine()
        {
        }

        public SignatureLine(Document doc)
        {
            Document = doc;
        }

        public SignatureLine(Document doc, string role)
            : this(doc)
        {
            Role = role;
        }

        public SignatureLine(Document doc, string role, int signOrder)
            : this(doc, role)
        {
            SignOrder = signOrder;
        }

        public SignatureLine(Document doc, string role, int signOrder, string conditions)
            : this(doc, role, signOrder)
        {
            Conditions = conditions;
        }

        public Document Document { get; internal set; }
        public string Role { get; set; }
        public string Conditions { get; set; }
        public int SignOrder { get; set; }
        public DateTime SignedAt { get; internal set; }
        public int? SignerId { get; set; }

        internal override Entity Parent
        {
            get { return Document; }
        }

        public Signer Signer
        {
            get
            {
                if (_signer == null)
                {
                    if (SignerId.HasValue)
                    {
                        _signer = Document.CaseFile.FindSigner(SignerId.Value);
                    }
                    else
                    {
                        _signer = GetLinkedEntities<Signer>().FirstOrDefault();
                        if (_signer != null)
                        {
                            _signer.CaseFile = Document.CaseFile;
                        }
                    }
                }
                return _signer;
            }
            private set { _signer = value; }
        }


        public void SetSigner(Signer signer)
        {
            Signer = signer;
            LinkEntity(Signer);
        }
    }
}