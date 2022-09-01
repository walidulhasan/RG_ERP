

var getCompaniesLookupData = HttpRequest.AjaxData("Get", '/AlgoHR/CommonDropDown/GetDDLCompanyLookUp', {});

var getDivisionsLookupData = HttpRequest.AjaxData("Get", '/AlgoHR/CommonDropDown/GetDDLDivisionLookUp', {});

var getDepartmentsLookupData = HttpRequest.AjaxData("Get", '/AlgoHR/CommonDropDown/GetDDLDepartmentLookUp', {});

var getSectionsLookupData = HttpRequest.AjaxData("Get", '/AlgoHR/CommonDropDown/GetDDLSectionLookUp', {});
var getSectionDesignationLookupData = HttpRequest.AjaxData("Get", '/AlgoHR/CommonDropDown/GetDDLSectionDesignationLookup', {});


function getDesignationsLookupData(companyID, divisionID, departmentID, sectionID, predict) {
    return HttpRequest.AjaxData("Get", '/AlgoHR/CommonDropDown/GetDDLDesignationLookUp', { companyID: companyID, divisionID: divisionID, departmentID: departmentID, sectionID: sectionID, predict: predict});
}
function getEmployeesLookupDataAsync(companyID, divisionID, departmentID, sectionID, designation, predict) {
    return HttpRequest.AjaxData("Post", '/AlgoHR/CommonDropDown/GetDDLEmployeeLookUp', { companyID: companyID, divisionID: divisionID, departmentID: departmentID, sectionID: sectionID, designation: designation, predict: predict });
}

var getApprovalLevelsLookupData = [{
    "ID": 1,
    "Name": "1"
}, {
    "ID": 2,
    "Name": "2"
}, {
    "ID": 3,
    "Name": "3"
}, {
    "ID": 4,
    "Name": "4"
}, {
    "ID": 5,
    "Name": "5"
}];
var getTestData = [{
    "ID": 1,
    "ParentID": 183,
    "Name": "1"
}, {
    "ID": 2,
    "ParentID": 183,
    "Name": "2"
}, {
    "ID": 3,
    "ParentID": 183,
    "Name": "3"
}, {
    "ID": 4,
    "ParentID": 20183,
    "Name": "4"
}, {
    "ID": 5,
    "ParentID": 20183,
    "Name": "5"
}, {
    "ID": 6,
    "ParentID": 1,
    "Name": "6"
}, {
    "ID": 7,
    "ParentID": 1,
    "Name": "7"
}];