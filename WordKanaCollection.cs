using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MusicBeePlugin
{
    [Serializable]
    public class WordKanaCollection
        : BindingList<WordKanaPair>
    {
        public void AddRange(IEnumerable<WordKanaPair> collection)
        {
            foreach (var wkp in collection)
            {
                Add(wkp);
            }
        }

        public void AddRange(WordKanaCollection collection)
        {
            AddRange(collection.Items);
        }

        // ソート関連
        protected override bool SupportsSortingCore => true;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = Items as List<WordKanaPair>;

            if (items != null)
            {
                PropertyComparer<WordKanaPair> pc = new PropertyComparer<WordKanaPair>(prop, direction);
                items.Sort(pc);
                isSorted = true;
            }
            else
            {
                isSorted = false;
            }

            sortProperty  = prop;
            sortDirection = direction;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private bool isSorted;
        protected override bool IsSortedCore => isSorted;

        [NonSerialized]
        private PropertyDescriptor sortProperty;
        protected override PropertyDescriptor SortPropertyCore => sortProperty;

        private ListSortDirection sortDirection;
        protected override ListSortDirection SortDirectionCore => sortDirection;

        public class PropertyComparer<T>
            : IComparer<T>
        {
            private PropertyDescriptor name;
            private int sortDirection;

            public PropertyComparer(PropertyDescriptor propertyName, ListSortDirection direction)
            {
                name = propertyName;
                sortDirection = (direction == ListSortDirection.Ascending) ? 1 : -1;
            }

            public int Compare(T x, T y)
            {
                IComparable left  = name.GetValue(x) as IComparable;
                IComparable right = name.GetValue(y) as IComparable;

                int result;

                if (left != null)
                    result = left.CompareTo(right);
                else if (right == null)
                    result = 0;
                else
                    result = -1;

                return result * sortDirection;
            }
        }
    }

    [Serializable]
    public class WordKanaPair
    {
        [XmlAttribute]
        public bool Enabled { get; set; }
        [XmlElement]
        public string Word { get; set; }
        [XmlElement]
        public string Kana { get; set; }

        public WordKanaPair()
            : this(word: "", kana: "")
        { }

        public WordKanaPair(string word, string kana)
        {
            Enabled = true;
            Word = word;
            Kana = kana;
        }
    }
}
