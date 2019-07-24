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
        private readonly IEmployeeRepository _repo;
        
        public EmployeeService() {}

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(await _repo.GetAllEmployees());
        }

        public async Task<EmployeeDto> GetEmployeeById(Guid id)
        {
            return Mapper.Map<EmployeeDto>(await _repo.GetEmployeeById(id));
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeDto emp)
        {
            return Mapper.Map<EmployeeDto>(await _repo.CreateEmployee(Mapper.Map<Employee>(emp)));
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto emp)
        {
            return Mapper.Map<EmployeeDto>(await _repo.UpdateEmployee(Mapper.Map<Employee>(emp)));
        }

        public async Task<EmployeeDto> DeleteEmployeeById(Guid id)
        {
            return Mapper.Map<EmployeeDto>(await _repo.DeleteEmployeeById(id));
        }
    }
}