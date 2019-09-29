using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLayer.dto;
using ApplicationLayer.interfaces;
using AutoMapper;
using data.models;
using Repository.interfaces;

namespace ApplicationLayer.services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IDepartmentRepository _depRepo;
        private readonly IMapper _mapper;
        
        public EmployeeService() {}

        public EmployeeService(IEmployeeRepository empRepo, IDepartmentRepository depRepo, IMapper mapper)
        {
            _empRepo = empRepo;
            _depRepo = depRepo;
            _mapper = mapper;
        }
        public async Task<IList<EmployeeDto>> GetAllEmployees()
        {
            var allEmployees = await _empRepo.GetAllEmployees();
            return _mapper.Map<IList<Employee>, IList<EmployeeDto>>(allEmployees);
        }

        public async Task<EmployeeDto> GetEmployeeById(Guid id)
        {
            var selectedEmployee = await _empRepo.GetEmployeeById(id);
            return _mapper.Map<EmployeeDto>(selectedEmployee);
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeDto emp)
        {
            if (emp == null) throw new ArgumentException(nameof(emp));
            var checkedDepartment = await _empRepo.GetEmployeeById(emp.Id);
            if (checkedDepartment != null) throw new ArgumentException(nameof(emp));
            var savedEmployee = await _empRepo.SaveEmployee(_mapper.Map<Employee>(emp));
            return _mapper.Map<EmployeeDto>(savedEmployee);
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto emp)
        {
            if (emp == null) throw new ArgumentException(nameof(emp));
            var selectedEmployee = await _empRepo.GetEmployeeById(emp.Id);
            if (selectedEmployee == null) throw new ArgumentException(nameof(emp));
            var selectedDepartment = await _depRepo.GetDepartmentById(emp.DepartmentId);
            if (selectedDepartment == null) throw new ArgumentException(nameof(emp.DepartmentId));
            
            selectedEmployee.FirstName = emp.FirstName;
            selectedEmployee.LastName = emp.LastName;
            selectedEmployee.SetDepartment(_mapper.Map<Department>(emp.Department) ?? selectedDepartment);
            
            var resultEmployee = await _empRepo.SaveEmployee(_mapper.Map<Employee>(emp));
            return _mapper.Map<EmployeeDto>(resultEmployee);
        }

        public async Task<EmployeeDto> DeleteEmployeeById(Guid id)
        {
            var selectedEmployee = await _empRepo.GetEmployeeById(id);
            if (selectedEmployee == null) throw new ArgumentException(nameof(id));
            var deleteResult = await _empRepo.DeleteEmployeeById(id);
            return _mapper.Map<EmployeeDto>(deleteResult);
        }
    }
}