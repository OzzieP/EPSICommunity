using EPSICommunity.Model;
using EPSICommunity.Utils.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EPSICommunity.Views.Code
{
    public class CodeViewModel : ViewModelBase
    {
        private ExtraitCode _extraitCodeSelected;
        public readonly List<ExtraitCode> _listExtraitsCode;
        public ICollectionView ExtraitsCode { get; set; }

        public ExtraitCode SelectedExtraitCode
        {
            get { return _extraitCodeSelected; }
            set
            {
                _extraitCodeSelected = value;
                NotifyPropertyChanged("SelectedUser");
            }
        }

        public CodeViewModel()
        {
            _listExtraitsCode = dataUtils.GetListExtraitsCode();
            ExtraitsCode = CollectionViewSource.GetDefaultView(_listExtraitsCode);
            ExtraitsCode.Refresh();
        }
    }
}
