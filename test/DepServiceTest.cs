using ApplicationLayer.config.automapper;
using ApplicationLayer.dto;
using ApplicationLayer.interfaces;
using ApplicationLayer.services;
using AutoMapper;
using data.models;
using Moq;
using NUnit.Framework;
using Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test
{
    [TestFixture]
    public class DepServiceTest
    {
        private IMapper _mapper;
        private Mock<IDepartmentRepository> _mockDepRepo;
        private IDepartmentService _departmentService;
        private Guid obj1Id;
        private Guid obj2Id;
        private DepartmentDto dep1Model;
        private DepartmentDto dep2Model;

        [SetUp]
        protected void SetUp()
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<DomainDtoProfile>();
                cfg.AddProfile<DtoDomainProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            obj1Id = Guid.NewGuid();
            obj2Id = Guid.NewGuid();
            dep1Model = new DepartmentDto() { Id = obj1Id, Title = "Test Dep 1" };
            dep2Model = new DepartmentDto() { Id = obj2Id, Title = "Test Dep 2" };
            //_mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
            //    .Returns<Guid>(id => {
            //        if (_departments.Exists(d => d.Id == id) 
            //        {

            //        return _departments.Find(d => d.Id == dep.Id)
            //        })});
            //.Returns(_departments.);
        }
        
        [Test]
        public async Task TestGetAll()
        {
            var expected = new List<DepartmentDto>();
            expected.Add(dep1Model);
            expected.Add(dep2Model);

            var departments = new List<Department>();
            departments.Add(_mapper.Map<DepartmentDto, Department>(dep1Model));
            departments.Add(_mapper.Map<DepartmentDto, Department>(dep2Model));

            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetAllDepartments()).Returns(Task.FromResult(departments));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            var result = await _departmentService.GetAllDepartments();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task TestGetById()
        {
            var expected = dep1Model;

            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(dep1Model)));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            var result = await _departmentService.GetDepartmentById(obj1Id);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task TestGetNullObjById()
        {
            DepartmentDto expected = null;

            DepartmentDto nullDep = null;
            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(nullDep)));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            var result = await _departmentService.GetDepartmentById(obj1Id);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task TestCreateObj()
        {
            var expected = dep1Model;

            DepartmentDto nullDep = null;
            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(nullDep)));
            _mockDepRepo.Setup(r => r.SaveDepartment(It.IsAny<Department>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(dep1Model)));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            var result = await _departmentService.CreateDepartment(dep1Model);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestCreateNullObj()
        {
            DepartmentDto nullDep = null;
            _mockDepRepo = new Mock<IDepartmentRepository>();
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            var depToCreate = nullDep;

            Assert.That(() => _departmentService.CreateDepartment(depToCreate), 
                Throws.ArgumentException.And.Message.EqualTo("dep"));
        }

        [Test]
        public void TestCreateExistingObj()
        {
            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(dep1Model)));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            var depToCreate = dep1Model;

            Assert.That(() => _departmentService.CreateDepartment(depToCreate),
                Throws.ArgumentException.And.Message.EqualTo("dep"));
        }

        [Test]
        public async Task TestUpdateObj()
        {
            var dep1ModelModded = new DepartmentDto() { Id = obj1Id, Title = "Test Dep 1 Modded" };
            var expected = dep1ModelModded;

            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(dep1Model)));
            _mockDepRepo.Setup(r => r.SaveDepartment(It.IsAny<Department>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(dep1ModelModded)));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            var objToCreate = dep1ModelModded;
            var result = await _departmentService.UpdateDepartment(objToCreate);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestUpdateNullObj()
        {
            DepartmentDto nullObj = null;

            _mockDepRepo = new Mock<IDepartmentRepository>();
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            Assert.That(() => _departmentService.UpdateDepartment(nullObj),
                Throws.ArgumentException.And.Message.EqualTo("dep"));
        }

        [Test]
        public void TestUpdateNonExistingObj()
        {
            DepartmentDto nullObj = null;

            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(nullObj)));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            Assert.That(() => _departmentService.UpdateDepartment(dep1Model),
                Throws.ArgumentException.And.Message.EqualTo("dep"));
        }

        [Test]
        public async Task TestDeleteObj()
        {
            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(dep1Model)));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            await _departmentService.DeleteDepartmentById(obj1Id);
            Assert.Pass();
        }

        [Test]
        public void TestDeleteNonExistingObj()
        {
            DepartmentDto nullObj = null;

            _mockDepRepo = new Mock<IDepartmentRepository>();
            _mockDepRepo.Setup(r => r.GetDepartmentById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mapper.Map<DepartmentDto, Department>(nullObj)));
            _departmentService = new DepartmentService(_mockDepRepo.Object, _mapper);

            Assert.That(() => _departmentService.DeleteDepartmentById(obj1Id),
                Throws.ArgumentException.And.Message.EqualTo("id"));
        }
    }
}