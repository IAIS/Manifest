using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Manifest.Annotations;

namespace Manifest.Utils
{
    public interface IDetails<T>
    {
        void Init(ObservableCollection<T> items);

        bool Validate();

        void Add(T item);

         void HandleDataGrid();
    }
}
