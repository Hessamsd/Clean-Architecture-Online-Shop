﻿using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;
        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();

            var pictureName = _fileUploader.Upload(command.Picture,"Slides");

            var slide = new Slide(pictureName, command.PictureAlt, command.PictureTitle,
                command.Text, command.Heading, command.Title,command.Link,command.BtnText);

            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();

            var slide = _slideRepository.Get(command.Id);

            if (slide == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            var pictureName = _fileUploader.Upload(command.Picture,"Slides");

            slide.Edit(pictureName, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text, command.Link,command.BtnText);

            _slideRepository.SaveChanges();
            return operation.Succedded();

        }

        public EditSlide GetDetails(int id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);

            if (slide == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);

            if (slide == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}
