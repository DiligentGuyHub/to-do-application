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

namespace ToDo.WPF.Commands
{
    public class UploadImageCommand : AsyncCommandBase
    {
        private IImageService _imageService;
        private IAccountService _accountService;
        private IAccountStore _accountStore;
        private TaskSummaryViewModel _taskSummaryViewModel;

        public UploadImageCommand(IAccountStore accountStore, TaskSummaryViewModel taskSummaryViewModel, IImageService imageService, IAccountService accountService)
        {
            _taskSummaryViewModel = taskSummaryViewModel;
            _accountStore = accountStore;
            _imageService = imageService;
            _accountService = accountService;
        }

        public async override System.Threading.Tasks.Task ExecuteAsync(object parameter)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JPG (*.jpg)|*.jpg| PNG (*.png)|*.png| BMP (*.bmp)|*.bmp| WEBP (*.webp)|*.webp";
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;

                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    var binaryFile = binaryReader.ReadBytes((int)fileStream.Length);

                    AttachedImage image = new AttachedImage()
                    {
                        TaskId = _taskSummaryViewModel.SelectedTask,
                        Image = binaryFile
                    };
                    await _imageService.Create(image);
                }
            }
        }
    }
}
