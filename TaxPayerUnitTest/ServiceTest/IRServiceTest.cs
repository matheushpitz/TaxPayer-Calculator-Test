using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxPayer.Service.IR;
using TaxPayer.ViewModel;
using TaxPayerUnitTest.Factory;

namespace TaxPayerUnitTest.ServiceTest
{
    [TestClass]
    public class IRServiceTest
    {
        private readonly IRService _service;

        public IRServiceTest()
        {
            _service = new IRService();
        }

        #region GetDependentDiscount
        [TestMethod]
        public void GetDependentDiscount_ZeroDependents()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(0);            

            decimal minimumSalary = 3000m;            

            decimal result = _service.GetDependentDiscount(minimumSalary, payer);

            Assert.AreEqual(decimal.Zero, result, "Error on function GetDependentDiscount when passing zero dependents");
            
        }

        [TestMethod]
        public void GetDependentDiscount_ThreeDependents()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(3);            

            decimal minimumSalary = 4000m;

            decimal result = _service.GetDependentDiscount(minimumSalary, payer);

            Assert.AreEqual(600m, result, "Error on function GetDependentDiscount when passing three dependents");

        }

        [TestMethod]
        public void GetDependentDiscount_NoMinimumSalary()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(3);            

            decimal minimumSalary = decimal.Zero;

            decimal result = _service.GetDependentDiscount(minimumSalary, payer);

            Assert.AreEqual(decimal.Zero, result, "Error on function GetDependentDiscount when passing minimumSalary as zero");

        }
        #endregion

        #region GetIRDiscount
        [TestMethod]
        public void GetIRDiscount_SalaryLessThan2MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 1800m);            

            decimal minimumSalary = 1000m;

            decimal result = _service.GetIRDiscount(minimumSalary, payer);

            Assert.AreEqual(decimal.Zero, result, "Error on function GetIRDiscount when passing GrossSalary as less than 2 Minimum Salaries");

        }

        [TestMethod]
        public void GetIRDiscount_SalaryLessThan4MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 3000m);            

            decimal minimumSalary = 1000m;

            decimal result = _service.GetIRDiscount(minimumSalary, payer);

            Assert.AreEqual(125m, result, "Error on function GetIRDiscount when passing GrossSalary as less than 4 Minimum Salaries");

        }

        [TestMethod]
        public void GetIRDiscount_SalaryLessThan5MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 4500m);

            decimal minimumSalary = 1000m;

            decimal result = _service.GetIRDiscount(minimumSalary, payer);

            Assert.AreEqual(575m, result, "Error on function GetIRDiscount when passing GrossSalary as less than 5 Minimum Salaries");

        }

        [TestMethod]
        public void GetIRDiscount_SalaryLessThan7MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 6000m);

            decimal minimumSalary = 1000m;

            decimal result = _service.GetIRDiscount(minimumSalary, payer);

            Assert.AreEqual(1250m, result, "Error on function GetIRDiscount when passing GrossSalary as less than 7 Minimum Salaries");

        }

        [TestMethod]
        public void GetIRDiscount_SalaryMoreThan7MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 8000m);

            decimal minimumSalary = 1000m;

            decimal result = _service.GetIRDiscount(minimumSalary, payer);

            Assert.AreEqual(2100m, result, "Error on function GetIRDiscount when passing GrossSalary as more than 7 Minimum Salaries");

        }
        #endregion

        #region ApplyIR
        [TestMethod]
        public void ApplyIR_SalaryLessThan2MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 1800m);

            decimal minimumSalary = 1000m;

            _service.ApplyIR(minimumSalary, payer);

            Assert.AreEqual(1800m, payer.NetSalary, "Error on function ApplyIR when passing GrossSalary as less than 2 Minimum Salaries");

        }

        [TestMethod]
        public void ApplyIR_SalaryLessThan4MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 3000m);

            decimal minimumSalary = 1000m;

            _service.ApplyIR(minimumSalary, payer);

            Assert.AreEqual(2875m, payer.NetSalary, "Error on function ApplyIR when passing GrossSalary as less than 4 Minimum Salaries");

        }

        [TestMethod]
        public void ApplyIR_SalaryLessThan5MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 4500m);

            decimal minimumSalary = 1000m;

            _service.ApplyIR(minimumSalary, payer);

            Assert.AreEqual(3925m, payer.NetSalary, "Error on function ApplyIR when passing GrossSalary as less than 5 Minimum Salaries");

        }

        [TestMethod]
        public void ApplyIR_SalaryLessThan7MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 6000m);

            decimal minimumSalary = 1000m;

            _service.ApplyIR(minimumSalary, payer);

            Assert.AreEqual(4750m, payer.NetSalary, "Error on function ApplyIR when passing GrossSalary as less than 7 Minimum Salaries");

        }

        [TestMethod]
        public void ApplyIR_SalaryMoreThan7MS()
        {
            PayerViewModel payer = PayerViewModelFactory.CreatePayer(2, 8000m);

            decimal minimumSalary = 1000m;

            _service.ApplyIR(minimumSalary, payer);

            Assert.AreEqual(5900m, payer.NetSalary, "Error on function ApplyIR when passing GrossSalary as more than 7 Minimum Salaries");

        }
        #endregion
    }
}
