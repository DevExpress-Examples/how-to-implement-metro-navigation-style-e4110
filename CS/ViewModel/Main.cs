using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Core.MvvmSample;
using DevExpress.Xpf.Core.MvvmSample.Helpers;
using System.Windows.Input;

namespace MertopolisNavigationSample.ViewModel {
    public class Main : MainModule {
        #region Commands
        protected override void InitializeCommands() {
            base.InitializeCommands();
            ShowMainCommand = CreateShowModuleCommand<Main>();
            ShowFirstViewCommand = CreateShowModuleCommand<First>();
            ShowSecondViewCommand = CreateShowModuleCommand<Second>();
        }
        public ICommand ShowMainCommand { get; private set; }
        public ICommand ShowFirstViewCommand { get; private set; }
        public ICommand ShowSecondViewCommand { get; private set; }
        #endregion
    }
}
