using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.ViewModels;
using Task = System.Threading.Tasks.Task;

namespace ToDo.WPF.Commands
{
    public class UploadFileCommand : AsyncCommandBase
    {
        private IAccountService _accountService;
        private IAccountStore _accountStore;
        private IFileService _fileService;
        private TaskSummaryViewModel _taskSummaryViewModel;

        public UploadFileCommand(IAccountStore accountStore, TaskSummaryViewModel taskSummaryViewModel, IFileService fileService, IAccountService accountService)
        {
            _taskSummaryViewModel = taskSummaryViewModel;
            _accountStore = accountStore;
            _fileService = fileService;
            _accountService = accountService;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "ANY (*.*)|*.*";
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;

                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    var binaryFile = binaryReader.ReadBytes((int)fileStream.Length);

                    AttachedFile file = new AttachedFile()
                    {
                        TaskId = _taskSummaryViewModel.SelectedTask,
                        Filename = Path.GetFileName(fileDialog.FileName),
                        File = binaryFile
                    };
                    await _fileService.Create(file);

                }
            }
        }
    }
}
