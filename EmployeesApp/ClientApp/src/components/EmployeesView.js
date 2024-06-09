import React, { useEffect, useState } from 'react';
import SummaryView from './SummaryView';
import AddEmployee from './AddEmployee';

const EmployeesView = () => {
    const [employees, setEmployees] = useState([]);
    const [isEmployeeViewOpen, setIsEmployeeViewOpen] = useState(false);
    const [isEditViewOpen, setIsEditViewOpen] = useState(false);
    const [currentEmployee, setCurrentEmployee] = useState(null);
    const [isAddEmployeeOpen, setIsAddEmployeeOpen] = useState(false);

    // State for filtering, sorting, and pagination
    const [filterBy, setFilterBy] = useState('');
    const [filterQuery, setFilterQuery] = useState('');
    const [sortBy, setSortBy] = useState('');
    const [isAsc, setIsAsc] = useState(true);
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(20);
    const [totalPages, setTotalPages] = useState(1);

    async function fetchEmployees() {
        try {
            const response = await fetch(
                `/api/employees?filterOn=${filterBy}&filterQuery=${filterQuery}&sortBy=${sortBy}&isAsc=${isAsc}&pageNumber=${pageNumber}&pageSize=${pageSize}`
            );
            const data = await response.json();
            setEmployees(data);
            console.log('Employees fetched:', data);
            
        } catch (error) {
            console.error('Failed to fetch employees:', error);
        }
    }

    function openEmployeeSummary(employee) {
        setIsEmployeeViewOpen(true);
        setCurrentEmployee(employee);
    }

    function openEmployeeEditDialog(employee) {
        setIsEditViewOpen(true);
        setCurrentEmployee(employee);
    }

    function openAddEmployeeDialog() {
        setIsAddEmployeeOpen(true);
        setCurrentEmployee(null);
    }

    async function deleteEmployee(employeeId) {
        const confirmed = window.confirm('Are you sure you want to delete this employee?');
        if (!confirmed) {
            return;
        }

        try {
            const response = await fetch(`/api/employees/${employeeId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.ok) {
                fetchEmployees();
            } else {
                console.error('Failed to delete employee');
                window.alert('Failed to delete employee');
            }
        } catch (error) {
            console.error('Error deleting employee:', error);
        }
    }
    const handleFilterChange = (e) => {
        setFilterBy(e.target.value);
    };

    const handleSortChange = (e) => {
        setSortBy(e.target.value);
    };
    const handlePageChange = (e) => {
        const newPageNumber = Math.max(1, Math.min(totalPages, Number(e.target.value)));
        setPageNumber(newPageNumber);
    };

    const handlePageSizeChange = (e) => {
        const newPageSize = Math.max(1, Math.min(50, Number(e.target.value)));
        setPageSize(newPageSize);
    };

    useEffect(() => {
        fetchEmployees();
    }, [filterBy, filterQuery, sortBy, isAsc, pageNumber, pageSize, fetchEmployees]);

    let allEmployeesView = (
        <div>
            <h1>Employee Overview</h1>
            <button className="btn btn-primary" onClick={openAddEmployeeDialog}>Add New Employee</button>

            {/* Filter and Sort Controls */}
            <div>
                <div className="form-group">
                    <label>Filter By:</label>
                    <select className="form-control" value={filterBy} onChange={handleFilterChange}>
                        {/*<option value="">None</option>*/}
                        <option value="surname">Surname</option>
                        <option value="name">Name</option>
                        <option value="department">Department</option>
                         
                    </select>
                </div>

                <div className="form-group">
                    <label>Filter Query:</label>
                    <input
                        type="text"
                        className="form-control"
                        value={filterQuery}
                        onChange={(e) => setFilterQuery(e.target.value)}
                    />
                </div>

                <div className="form-group">
                    <label>Sort By:</label>
                    <select className="form-control" value={sortBy} onChange={handleSortChange}>
                        <option value="">None</option>
                        <option value="surname">Surname</option>
                        <option value="name">Name</option>
                        <option value="department">Department</option>
                        
                    </select>
                </div>

                <div className="form-group">
                    <label>Sort Order:</label>
                    <select className="form-control" value={isAsc} onChange={(e) => setIsAsc(e.target.value === 'true')}>
                        <option value="true">Ascending</option>
                        <option value="false">Descending</option>
                    </select>
                </div>
            </div>

            Pagination Controls 
            <div>
                <div className="form-group">
                    <label>Page Number:</label>
                    <input
                        type="number"
                        className="form-control"
                        value={pageNumber}
                        onChange={handlePageChange}
                        min="1"
                        max={totalPages}
                    />
                </div>

                <div className="form-group">
                    <label>Page Size:</label>
                    <input
                        type="number"
                        className="form-control"
                        value={pageSize}
                        onChange={handlePageSizeChange}
                        min="1"
                        max="50"
                    />
                </div>
            </div>

            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Gender</th>
                        <th>Date of Birth</th>
                        <th>Start Date</th>
                        <th>Department</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.length > 0 ? (
                        employees.map((employee) => (
                            <tr key={employee.id}>
                                <td>{employee.name}</td>
                                <td>{employee.surname}</td>
                                <td>{employee.gender}</td>
                                <td>{new Date(employee.dateOfBirth).toLocaleDateString()}</td>
                                <td>{new Date(employee.startDateOfEmployment).toLocaleDateString()}</td>
                                <td>{employee.department}</td>
                                <td>
                                    <button className="btn btn-primary" onClick={() => openEmployeeSummary(employee)}>Open Summary</button>
                                    <button className="btn btn-primary" onClick={() => openEmployeeEditDialog(employee)}>Edit</button>
                                    <button className="btn btn-primary" onClick={() => deleteEmployee(employee.id)}>Delete</button>
                                </td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="7">No employees found.</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );

    return (
        <div>
            {isEmployeeViewOpen ? (
                <SummaryView
                    employee={currentEmployee}
                    setIsEmployeeViewOpen={setIsEmployeeViewOpen}
                    setIsEditViewOpen={setIsEditViewOpen}
                />
            ) : isEditViewOpen || isAddEmployeeOpen ? (
                <AddEmployee
                    employeeData={currentEmployee}
                    onSave={() => {
                        setIsEditViewOpen(false);
                        setIsAddEmployeeOpen(false);
                        fetchEmployees();
                    }}
                    onCancel={() => {
                        setIsEditViewOpen(false);
                        setIsAddEmployeeOpen(false);
                    }}
                />
            ) : (
                allEmployeesView
            )}
        </div>
    );
};

export default EmployeesView;
