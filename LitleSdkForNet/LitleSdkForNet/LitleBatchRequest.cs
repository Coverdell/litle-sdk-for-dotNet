using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Litle.Sdk.Properties;

namespace Litle.Sdk
{
    public class BatchRequest
    {
        public string ID;
        public string MerchantId;
        public string ReportGroup;

        public Dictionary<String, String> Config;

        public string BatchFilePath;
        private string _tempBatchFilePath;
        private LitleFile _litleFile;
        private LitleTime _litleTime;
        private string _requestDirectory;
        private string _responseDirectory;

        private int _numAuthorization;
        private int _numAccountUpdates;
        private int _numCapture;
        private int _numCredit;
        private int _numSale;
        private int _numAuthReversal;
        private int _numEcheckCredit;
        private int _numEcheckVerification;
        private int _numEcheckSale;
        private int _numRegisterTokenRequest;
        private int _numForceCapture;
        private int _numCaptureGivenAuth;
        private int _numEcheckRedeposit;
        private int _numEcheckPreNoteSale;
        private int _numEcheckPreNoteCredit;
        private int _numUpdateCardValidationNumOnToken;
        private int _numUpdateSubscriptions;
        private int _numCancelSubscriptions;
        private int _numCreatePlans;
        private int _numUpdatePlans;
        private int _numActivates;
        private int _numDeactivates;
        private int _numLoads;
        private int _numUnloads;
        private int _numBalanceInquiries;
        private int _numPayFacCredit;
        private int _numSubmerchantCredit;
        private int _numReserveCredit;
        private int _numVendorCredit;
        private int _numPhysicalCheckCredit;
        private int _numPayFacDebit;
        private int _numSubmerchantDebit;
        private int _numReserveDebit;
        private int _numVendorDebit;
        private int _numPhysicalCheckDebit;

        private long _sumOfAuthorization;
        private long _sumOfAuthReversal;
        private long _sumOfCapture;
        private long _sumOfCredit;
        private long _sumOfSale;
        private long _sumOfForceCapture;
        private long _sumOfEcheckSale;
        private long _sumOfEcheckCredit;
        private long _sumOfEcheckVerification;
        private long _sumOfCaptureGivenAuth;
        private long _activateAmount;
        private long _loadAmount;
        private long _unloadAmount;
        private long _payFacCreditAmount;
        private long _submerchantCreditAmount;
        private long _reserveCreditAmount;
        private long _vendorCreditAmount;
        private long _physicalCheckCreditAmount;
        private long _payFacDebitAmount;
        private long _submerchantDebitAmount;
        private long _reserveDebitAmount;
        private long _vendorDebitAmount;
        private long _physicalCheckDebitAmount;

        private const string AccountUpdateErrorMessage = "Account Updates need to exist in their own batch request!";

        public BatchRequest()
        {
            Config = new Dictionary<String, String>();
            Config["url"] = Settings.Default.url;
            Config["reportGroup"] = Settings.Default.reportGroup;
            Config["username"] = Settings.Default.username;
            Config["printxml"] = Settings.Default.printxml;
            Config["timeout"] = Settings.Default.timeout;
            Config["proxyHost"] = Settings.Default.proxyHost;
            Config["merchantId"] = Settings.Default.merchantId;
            Config["password"] = Settings.Default.password;
            Config["proxyPort"] = Settings.Default.proxyPort;
            Config["sftpUrl"] = Settings.Default.sftpUrl;
            Config["sftpUsername"] = Settings.Default.sftpUsername;
            Config["sftpPassword"] = Settings.Default.sftpPassword;
            Config["knownHostsFile"] = Settings.Default.knownHostsFile;
            Config["requestDirectory"] = Settings.Default.requestDirectory;
            Config["responseDirectory"] = Settings.Default.responseDirectory;

            InitializeRequest();
        }

        public BatchRequest(Dictionary<String, String> config)
        {
            Config = config;
            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _requestDirectory = Config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = Config["responseDirectory"] + "\\Responses\\";

            _litleFile = new LitleFile();
            _litleTime = new LitleTime();

            _numAuthorization = 0;
            _numAuthReversal = 0;
            _numCapture = 0;
            _numCaptureGivenAuth = 0;
            _numCredit = 0;
            _numEcheckCredit = 0;
            _numEcheckRedeposit = 0;
            _numEcheckPreNoteSale = 0;
            _numEcheckPreNoteCredit = 0;
            _numEcheckSale = 0;
            _numEcheckVerification = 0;
            _numForceCapture = 0;
            _numRegisterTokenRequest = 0;
            _numSale = 0;
            _numUpdateCardValidationNumOnToken = 0;
            _numUpdateSubscriptions = 0;
            _numCancelSubscriptions = 0;
            _numPayFacCredit = 0;
            _numSubmerchantCredit = 0;
            _numReserveCredit = 0;
            _numVendorCredit = 0;
            _numPhysicalCheckCredit = 0;
            _numPayFacDebit = 0;
            _numSubmerchantDebit = 0;
            _numReserveDebit = 0;
            _numVendorDebit = 0;
            _numPhysicalCheckDebit = 0;

            _sumOfAuthorization = 0;
            _sumOfAuthReversal = 0;
            _sumOfCapture = 0;
            _sumOfCredit = 0;
            _sumOfSale = 0;
            _sumOfForceCapture = 0;
            _sumOfEcheckSale = 0;
            _sumOfEcheckCredit = 0;
            _sumOfEcheckVerification = 0;
            _sumOfCaptureGivenAuth = 0;
            _payFacCreditAmount = 0;
            _submerchantCreditAmount = 0;
            _reserveCreditAmount = 0;
            _vendorCreditAmount = 0;
            _physicalCheckCreditAmount = 0;
            _payFacDebitAmount = 0;
            _submerchantDebitAmount = 0;
            _reserveDebitAmount = 0;
            _vendorDebitAmount = 0;
            _physicalCheckDebitAmount = 0;
        }

        public string GetResponseDirectory()
        {
            return _responseDirectory;
        }

        public string GetRequestDirectory()
        {
            return _requestDirectory;
        }

        public void SetLitleFile(LitleFile litleFile)
        {
            _litleFile = litleFile;
        }

        public LitleFile GetLitleFile()
        {
            return _litleFile;
        }

        public void SetLitleTime(LitleTime litleTime)
        {
            _litleTime = litleTime;
        }

        public LitleTime GetLitleTime()
        {
            return _litleTime;
        }

        public int GetNumAuthorization()
        {
            return _numAuthorization;
        }

        public int GetNumAccountUpdates()
        {
            return _numAccountUpdates;
        }

        public int GetNumCapture()
        {
            return _numCapture;
        }

        public int GetNumCredit()
        {
            return _numCredit;
        }

        public int GetNumSale()
        {
            return _numSale;
        }

        public int GetNumAuthReversal()
        {
            return _numAuthReversal;
        }

        public int GetNumEcheckCredit()
        {
            return _numEcheckCredit;
        }

        public int GetNumEcheckVerification()
        {
            return _numEcheckVerification;
        }

        public int GetNumEcheckSale()
        {
            return _numEcheckSale;
        }

        public int GetNumRegisterTokenRequest()
        {
            return _numRegisterTokenRequest;
        }

        public int GetNumForceCapture()
        {
            return _numForceCapture;
        }

        public int GetNumCaptureGivenAuth()
        {
            return _numCaptureGivenAuth;
        }

        public int GetNumEcheckRedeposit()
        {
            return _numEcheckRedeposit;
        }

        public int GetNumEcheckPreNoteSale()
        {
            return _numEcheckPreNoteSale;
        }

        public int GetNumEcheckPreNoteCredit()
        {
            return _numEcheckPreNoteCredit;
        }

        public int GetNumUpdateCardValidationNumOnToken()
        {
            return _numUpdateCardValidationNumOnToken;
        }

        public int GetNumUpdateSubscriptions()
        {
            return _numUpdateSubscriptions;
        }

        public int GetNumCancelSubscriptions()
        {
            return _numCancelSubscriptions;
        }

        public int GetNumCreatePlans()
        {
            return _numCreatePlans;
        }

        public int GetNumUpdatePlans()
        {
            return _numUpdatePlans;
        }

        public int GetNumActivates()
        {
            return _numActivates;
        }

        public int GetNumDeactivates()
        {
            return _numDeactivates;
        }

        public int GetNumLoads()
        {
            return _numLoads;
        }

        public int GetNumUnloads()
        {
            return _numUnloads;
        }

        public int GetNumBalanceInquiries()
        {
            return _numBalanceInquiries;
        }

        public int GetNumPayFacCredit()
        {
            return _numPayFacCredit;
        }

        public int GetNumSubmerchantCredit()
        {
            return _numSubmerchantCredit;
        }

        public int GetNumReserveCredit()
        {
            return _numReserveCredit;
        }

        public int GetNumVendorCredit()
        {
            return _numVendorCredit;
        }

        public int GetNumPhysicalCheckCredit()
        {
            return _numPhysicalCheckCredit;
        }

        public int GetNumPayFacDebit()
        {
            return _numPayFacDebit;
        }

        public int GetNumSubmerchantDebit()
        {
            return _numSubmerchantDebit;
        }

        public int GetNumReserveDebit()
        {
            return _numReserveDebit;
        }

        public int GetNumVendorDebit()
        {
            return _numVendorDebit;
        }

        public int GetNumPhysicalCheckDebit()
        {
            return _numPhysicalCheckDebit;
        }

        public long GetLoadAmount()
        {
            return _loadAmount;
        }

        public long GetUnloadAmount()
        {
            return _unloadAmount;
        }

        public long GetActivateAmount()
        {
            return _activateAmount;
        }

        public long GetSumOfAuthorization()
        {
            return _sumOfAuthorization;
        }

        public long GetSumOfAuthReversal()
        {
            return _sumOfAuthReversal;
        }

        public long GetSumOfCapture()
        {
            return _sumOfCapture;
        }

        public long GetSumOfCredit()
        {
            return _sumOfCredit;
        }

        public long GetSumOfSale()
        {
            return _sumOfSale;
        }

        public long GetSumOfForceCapture()
        {
            return _sumOfForceCapture;
        }

        public long GetSumOfEcheckSale()
        {
            return _sumOfEcheckSale;
        }

        public long GetSumOfEcheckCredit()
        {
            return _sumOfEcheckCredit;
        }

        public long GetSumOfEcheckVerification()
        {
            return _sumOfEcheckVerification;
        }

        public long GetSumOfCaptureGivenAuth()
        {
            return _sumOfCaptureGivenAuth;
        }

        public long GetPayFacCreditAmount()
        {
            return _payFacCreditAmount;
        }

        public long GetSubmerchantCreditAmount()
        {
            return _submerchantCreditAmount;
        }

        public long GetReserveCreditAmount()
        {
            return _reserveCreditAmount;
        }

        public long GetVendorCreditAmount()
        {
            return _vendorCreditAmount;
        }

        public long GetPhysicalCheckCreditAmount()
        {
            return _physicalCheckCreditAmount;
        }

        public long GetPayFacDebitAmount()
        {
            return _payFacDebitAmount;
        }

        public long GetSubmerchantDebitAmount()
        {
            return _submerchantDebitAmount;
        }

        public long GetReserveDebitAmount()
        {
            return _reserveDebitAmount;
        }

        public long GetVendorDebitAmount()
        {
            return _vendorDebitAmount;
        }

        public long GetPhysicalCheckDebitAmount()
        {
            return _physicalCheckDebitAmount;
        }

        public void AddAuthorization(authorization authorization)
        {
            if (_numAccountUpdates == 0)
            {
                _numAuthorization++;
                _sumOfAuthorization += authorization.amount;
                FillInReportGroup(authorization);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, authorization);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddCapture(capture capture)
        {
            if (_numAccountUpdates == 0)
            {
                _numCapture++;
                _sumOfCapture += capture.amount;
                FillInReportGroup(capture);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, capture);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddCredit(credit credit)
        {
            if (_numAccountUpdates == 0)
            {
                _numCredit++;
                _sumOfCredit += credit.amount;
                FillInReportGroup(credit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, credit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddSale(sale sale)
        {
            if (_numAccountUpdates == 0)
            {
                _numSale++;
                _sumOfSale += sale.amount;
                FillInReportGroup(sale);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, sale);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddAuthReversal(authReversal authReversal)
        {
            if (_numAccountUpdates == 0)
            {
                _numAuthReversal++;
                _sumOfAuthReversal += authReversal.amount;
                FillInReportGroup(authReversal);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, authReversal);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddEcheckCredit(echeckCredit echeckCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckCredit++;
                _sumOfEcheckCredit += echeckCredit.amount;
                FillInReportGroup(echeckCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddEcheckVerification(echeckVerification echeckVerification)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckVerification++;
                _sumOfEcheckVerification += echeckVerification.amount;
                FillInReportGroup(echeckVerification);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckVerification);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddEcheckSale(echeckSale echeckSale)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckSale++;
                _sumOfEcheckSale += echeckSale.amount;
                FillInReportGroup(echeckSale);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckSale);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddRegisterTokenRequest(registerTokenRequestType registerTokenRequestType)
        {
            if (_numAccountUpdates == 0)
            {
                _numRegisterTokenRequest++;
                FillInReportGroup(registerTokenRequestType);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, registerTokenRequestType);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddForceCapture(forceCapture forceCapture)
        {
            if (_numAccountUpdates == 0)
            {
                _numForceCapture++;
                _sumOfForceCapture += forceCapture.amount;
                FillInReportGroup(forceCapture);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, forceCapture);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddCaptureGivenAuth(captureGivenAuth captureGivenAuth)
        {
            if (_numAccountUpdates == 0)
            {
                _numCaptureGivenAuth++;
                _sumOfCaptureGivenAuth += captureGivenAuth.amount;
                FillInReportGroup(captureGivenAuth);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, captureGivenAuth);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddEcheckRedeposit(echeckRedeposit echeckRedeposit)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckRedeposit++;
                FillInReportGroup(echeckRedeposit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckRedeposit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddEcheckPreNoteSale(EcheckPreNoteSale echeckPreNoteSale)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckPreNoteSale++;
                FillInReportGroup(echeckPreNoteSale);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckPreNoteSale);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddEcheckPreNoteCredit(EcheckPreNoteCredit echeckPreNoteCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckPreNoteCredit++;
                FillInReportGroup(echeckPreNoteCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckPreNoteCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken updateCardValidationNumOnToken)
        {
            if (_numAccountUpdates == 0)
            {
                _numUpdateCardValidationNumOnToken++;
                FillInReportGroup(updateCardValidationNumOnToken);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath,
                    updateCardValidationNumOnToken);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddUpdateSubscription(updateSubscription updateSubscription)
        {
            if (_numAccountUpdates == 0)
            {
                _numUpdateSubscriptions++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, updateSubscription);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddCancelSubscription(cancelSubscription cancelSubscription)
        {
            if (_numAccountUpdates == 0)
            {
                _numCancelSubscriptions++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, cancelSubscription);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddCreatePlan(createPlan createPlan)
        {
            if (_numAccountUpdates == 0)
            {
                _numCreatePlans++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, createPlan);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddUpdatePlan(updatePlan updatePlan)
        {
            if (_numAccountUpdates == 0)
            {
                _numUpdatePlans++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, updatePlan);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddActivate(activate activate)
        {
            if (_numAccountUpdates == 0)
            {
                _numActivates++;
                _activateAmount += activate.amount;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, activate);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddDeactivate(deactivate deactivate)
        {
            if (_numAccountUpdates == 0)
            {
                _numDeactivates++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, deactivate);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddLoad(load load)
        {
            if (_numAccountUpdates == 0)
            {
                _numLoads++;
                _loadAmount += load.amount;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, load);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddUnload(unload unload)
        {
            if (_numAccountUpdates == 0)
            {
                _numUnloads++;
                _unloadAmount += unload.amount;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, unload);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddBalanceInquiry(balanceInquiry balanceInquiry)
        {
            if (_numAccountUpdates == 0)
            {
                _numBalanceInquiries++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, balanceInquiry);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddAccountUpdate(accountUpdate accountUpdate)
        {
            if (IsOnlyAccountUpdates())
            {
                _numAccountUpdates++;
                FillInReportGroup(accountUpdate);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, accountUpdate);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddSubmerchantCredit(SubmerchantCredit submerchantCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numSubmerchantCredit++;
                if (submerchantCredit.Amount != null) _submerchantCreditAmount += (long) submerchantCredit.Amount;
                FillInReportGroup(submerchantCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, submerchantCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddPayFacCredit(PayFacCredit payFacCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numPayFacCredit++;
                if (payFacCredit.Amount != null) _payFacCreditAmount += (long) payFacCredit.Amount;
                FillInReportGroup(payFacCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, payFacCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddReserveCredit(ReserveCredit reserveCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numReserveCredit++;
                if (reserveCredit.Amount != null) _reserveCreditAmount += (long) reserveCredit.Amount;
                FillInReportGroup(reserveCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, reserveCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddVendorCredit(VendorCredit vendorCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numVendorCredit++;
                if (vendorCredit.Amount != null) _vendorCreditAmount += (long) vendorCredit.Amount;
                FillInReportGroup(vendorCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, vendorCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddPhysicalCheckCredit(PhysicalCheckCredit physicalCheckCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numPhysicalCheckCredit++;
                if (physicalCheckCredit.Amount != null) _physicalCheckCreditAmount += (long) physicalCheckCredit.Amount;
                FillInReportGroup(physicalCheckCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, physicalCheckCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddSubmerchantDebit(SubmerchantDebit submerchantDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numSubmerchantDebit++;
                if (submerchantDebit.Amount != null) _submerchantDebitAmount += (long) submerchantDebit.Amount;
                FillInReportGroup(submerchantDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, submerchantDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddPayFacDebit(PayFacDebit payFacDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numPayFacDebit++;
                if (payFacDebit.Amount != null) _payFacDebitAmount += (long) payFacDebit.Amount;
                FillInReportGroup(payFacDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, payFacDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddReserveDebit(ReserveDebit reserveDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numReserveDebit++;
                if (reserveDebit.Amount != null) _reserveDebitAmount += (long) reserveDebit.Amount;
                FillInReportGroup(reserveDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, reserveDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddVendorDebit(VendorDebit vendorDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numVendorDebit++;
                if (vendorDebit.Amount != null) _vendorDebitAmount += (long) vendorDebit.Amount;
                FillInReportGroup(vendorDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, vendorDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void AddPhysicalCheckDebit(PhysicalCheckDebit physicalCheckDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numPhysicalCheckDebit++;
                if (physicalCheckDebit.Amount != null) _physicalCheckDebitAmount += (long) physicalCheckDebit.Amount;
                FillInReportGroup(physicalCheckDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, physicalCheckDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public String Serialize()
        {
            string xmlHeader = GenerateXmlHeader();
            const string xmlFooter = "</batchRequest>\r\n";

            BatchFilePath = _litleFile.CreateRandomFile(_requestDirectory, null, "_batchRequest.xml", _litleTime);

            _litleFile.AppendLineToFile(BatchFilePath, xmlHeader);
            _litleFile.AppendFileToFile(BatchFilePath, _tempBatchFilePath);
            _litleFile.AppendLineToFile(BatchFilePath, xmlFooter);

            _tempBatchFilePath = null;

            return BatchFilePath;
        }

        public string GenerateXmlHeader()
        {
            string xmlHeader = "\r\n<batchRequest id=\"" + ID + "\"\r\n";

            if (_numAuthorization != 0)
            {
                xmlHeader += "numAuths=\"" + _numAuthorization + "\"\r\n";
                xmlHeader += "authAmount=\"" + _sumOfAuthorization + "\"\r\n";
            }

            if (_numAuthReversal != 0)
            {
                xmlHeader += "numAuthReversals=\"" + _numAuthReversal + "\"\r\n";
                xmlHeader += "authReversalAmount=\"" + _sumOfAuthReversal + "\"\r\n";
            }

            if (_numCapture != 0)
            {
                xmlHeader += "numCaptures=\"" + _numCapture + "\"\r\n";
                xmlHeader += "captureAmount=\"" + _sumOfCapture + "\"\r\n";
            }

            if (_numCredit != 0)
            {
                xmlHeader += "numCredits=\"" + _numCredit + "\"\r\n";
                xmlHeader += "creditAmount=\"" + _sumOfCredit + "\"\r\n";
            }

            if (_numForceCapture != 0)
            {
                xmlHeader += "numForceCaptures=\"" + _numForceCapture + "\"\r\n";
                xmlHeader += "forceCaptureAmount=\"" + _sumOfForceCapture + "\"\r\n";
            }

            if (_numSale != 0)
            {
                xmlHeader += "numSales=\"" + _numSale + "\"\r\n";
                xmlHeader += "saleAmount=\"" + _sumOfSale + "\"\r\n";
            }

            if (_numCaptureGivenAuth != 0)
            {
                xmlHeader += "numCaptureGivenAuths=\"" + _numCaptureGivenAuth + "\"\r\n";
                xmlHeader += "captureGivenAuthAmount=\"" + _sumOfCaptureGivenAuth + "\"\r\n";
            }

            if (_numEcheckSale != 0)
            {
                xmlHeader += "numEcheckSales=\"" + _numEcheckSale + "\"\r\n";
                xmlHeader += "echeckSalesAmount=\"" + _sumOfEcheckSale + "\"\r\n";
            }

            if (_numEcheckCredit != 0)
            {
                xmlHeader += "numEcheckCredit=\"" + _numEcheckCredit + "\"\r\n";
                xmlHeader += "echeckCreditAmount=\"" + _sumOfEcheckCredit + "\"\r\n";
            }

            if (_numEcheckVerification != 0)
            {
                xmlHeader += "numEcheckVerification=\"" + _numEcheckVerification + "\"\r\n";
                xmlHeader += "echeckVerificationAmount=\"" + _sumOfEcheckVerification + "\"\r\n";
            }

            if (_numEcheckRedeposit != 0)
            {
                xmlHeader += "numEcheckRedeposit=\"" + _numEcheckRedeposit + "\"\r\n";
            }

            if (_numEcheckPreNoteSale != 0)
            {
                xmlHeader += "numEcheckPreNoteSale=\"" + _numEcheckPreNoteSale + "\"\r\n";
            }

            if (_numEcheckPreNoteCredit != 0)
            {
                xmlHeader += "numEcheckPreNoteCredit=\"" + _numEcheckPreNoteCredit + "\"\r\n";
            }

            if (_numAccountUpdates != 0)
            {
                xmlHeader += "numAccountUpdates=\"" + _numAccountUpdates + "\"\r\n";
            }

            if (_numRegisterTokenRequest != 0)
            {
                xmlHeader += "numTokenRegistrations=\"" + _numRegisterTokenRequest + "\"\r\n";
            }

            if (_numUpdateCardValidationNumOnToken != 0)
            {
                xmlHeader += "numUpdateCardValidationNumOnTokens=\"" + _numUpdateCardValidationNumOnToken + "\"\r\n";
            }

            if (_numUpdateSubscriptions != 0)
            {
                xmlHeader += "numUpdateSubscriptions=\"" + _numUpdateSubscriptions + "\"\r\n";
            }

            if (_numCancelSubscriptions != 0)
            {
                xmlHeader += "numCancelSubscriptions=\"" + _numCancelSubscriptions + "\"\r\n";
            }

            if (_numCreatePlans != 0)
            {
                xmlHeader += "numCreatePlans=\"" + _numCreatePlans + "\"\r\n";
            }

            if (_numUpdatePlans != 0)
            {
                xmlHeader += "numUpdatePlans=\"" + _numUpdatePlans + "\"\r\n";
            }

            if (_numActivates != 0)
            {
                xmlHeader += "numUpdateActivates=\"" + _numActivates + "\"\r\n";
                xmlHeader += "activateAmount=\"" + _activateAmount + "\"\r\n";
            }

            if (_numDeactivates != 0)
            {
                xmlHeader += "numDeactivates=\"" + _numDeactivates + "\"\r\n";
            }

            if (_numLoads != 0)
            {
                xmlHeader += "numLoads=\"" + _numLoads + "\"\r\n";
                xmlHeader += "loadAmount=\"" + _loadAmount + "\"\r\n";
            }

            if (_numUnloads != 0)
            {
                xmlHeader += "numUnloads=\"" + _numUnloads + "\"\r\n";
                xmlHeader += "unloadAmount=\"" + _unloadAmount + "\"\r\n";
            }

            if (_numBalanceInquiries != 0)
            {
                xmlHeader += "numBalanceInquirys=\"" + _numBalanceInquiries + "\"\r\n";
            }

            if (_numPayFacCredit != 0)
            {
                xmlHeader += "numPayFacCredit=\"" + _numPayFacCredit + "\"\r\n";
                xmlHeader += "payFacCreditAmount=\"" + _payFacCreditAmount + "\"\r\n";
            }

            if (_numSubmerchantCredit != 0)
            {
                xmlHeader += "numSubmerchantCredit=\"" + _numSubmerchantCredit + "\"\r\n";
                xmlHeader += "submerchantCreditAmount=\"" + _submerchantCreditAmount + "\"\r\n";
            }

            if (_numReserveCredit != 0)
            {
                xmlHeader += "numReserveCredit=\"" + _numReserveCredit + "\"\r\n";
                xmlHeader += "reserveCreditAmount=\"" + _reserveCreditAmount + "\"\r\n";
            }

            if (_numVendorCredit != 0)
            {
                xmlHeader += "numVendorCredit=\"" + _numVendorCredit + "\"\r\n";
                xmlHeader += "vendorCreditAmount=\"" + _vendorCreditAmount + "\"\r\n";
            }

            if (_numPhysicalCheckCredit != 0)
            {
                xmlHeader += "numPhysicalCheckCredit=\"" + _numPhysicalCheckCredit + "\"\r\n";
                xmlHeader += "physicalCheckCreditAmount=\"" + _physicalCheckCreditAmount + "\"\r\n";
            }

            if (_numPayFacDebit != 0)
            {
                xmlHeader += "numPayFacDebit=\"" + _numPayFacDebit + "\"\r\n";
                xmlHeader += "payFacDebitAmount=\"" + _payFacDebitAmount + "\"\r\n";
            }

            if (_numSubmerchantDebit != 0)
            {
                xmlHeader += "numSubmerchantDebit=\"" + _numSubmerchantDebit + "\"\r\n";
                xmlHeader += "submerchantDebitAmount=\"" + _submerchantDebitAmount + "\"\r\n";
            }

            if (_numReserveDebit != 0)
            {
                xmlHeader += "numReserveDebit=\"" + _numReserveDebit + "\"\r\n";
                xmlHeader += "reserveDebitAmount=\"" + _reserveDebitAmount + "\"\r\n";
            }

            if (_numVendorDebit != 0)
            {
                xmlHeader += "numVendorDebit=\"" + _numVendorDebit + "\"\r\n";
                xmlHeader += "vendorDebitAmount=\"" + _vendorDebitAmount + "\"\r\n";
            }

            if (_numPhysicalCheckDebit != 0)
            {
                xmlHeader += "numPhysicalCheckDebit=\"" + _numPhysicalCheckDebit + "\"\r\n";
                xmlHeader += "physicalCheckDebitAmount=\"" + _physicalCheckDebitAmount + "\"\r\n";
            }

            xmlHeader += "merchantSdk=\"DotNet;9.3.2\"\r\n";
            xmlHeader += "merchantId=\"" + Config["merchantId"] + "\">\r\n";
            return xmlHeader;
        }

        private string SaveElement(LitleFile litleFile, LitleTime litleTime, string filePath, transactionRequest element)
        {
            string fPath = litleFile.CreateRandomFile(_requestDirectory, Path.GetFileName(filePath),
                "_temp_batchRequest.xml",
                litleTime);

            litleFile.AppendLineToFile(fPath, element.Serialize());

            return fPath;
        }

        private void FillInReportGroup(transactionTypeWithReportGroup txn)
        {
            if (txn.reportGroup == null)
            {
                txn.reportGroup = Config["reportGroup"];
            }
        }

        private void FillInReportGroup(transactionTypeWithReportGroupAndPartial txn)
        {
            if (txn.reportGroup == null)
            {
                txn.reportGroup = Config["reportGroup"];
            }
        }

        private bool IsOnlyAccountUpdates()
        {
            return _numAuthorization == 0
                   && _numCapture == 0
                   && _numCredit == 0
                   && _numSale == 0
                   && _numAuthReversal == 0
                   && _numEcheckCredit == 0
                   && _numEcheckVerification == 0
                   && _numEcheckSale == 0
                   && _numRegisterTokenRequest == 0
                   && _numForceCapture == 0
                   && _numCaptureGivenAuth == 0
                   && _numEcheckRedeposit == 0
                   && _numEcheckPreNoteSale == 0
                   && _numEcheckPreNoteCredit == 0
                   && _numUpdateCardValidationNumOnToken == 0
                   && _numUpdateSubscriptions == 0
                   && _numCancelSubscriptions == 0
                   && _numCreatePlans == 0
                   && _numUpdatePlans == 0
                   && _numActivates == 0
                   && _numDeactivates == 0
                   && _numLoads == 0
                   && _numUnloads == 0
                   && _numBalanceInquiries == 0
                   && _numPayFacCredit == 0
                   && _numSubmerchantCredit == 0
                   && _numReserveCredit == 0
                   && _numVendorCredit == 0
                   && _numPhysicalCheckCredit == 0
                   && _numPayFacDebit == 0
                   && _numSubmerchantDebit == 0
                   && _numReserveDebit == 0
                   && _numVendorDebit == 0
                   && _numPhysicalCheckDebit == 0;
        }
    }

    public class RfrRequest
    {
        public long LitleSessionId;
        public accountUpdateFileRequestData AccountUpdateFileRequestData;

        private LitleTime _litleTime;
        private LitleFile _litleFile;
        private string _requestDirectory;
        private string _responseDirectory;

        private Dictionary<String, String> _config;

        public RfrRequest()
        {
            _config = new Dictionary<String, String>();
            _config["url"] = Settings.Default.url;
            _config["reportGroup"] = Settings.Default.reportGroup;
            _config["username"] = Settings.Default.username;
            _config["printxml"] = Settings.Default.printxml;
            _config["timeout"] = Settings.Default.timeout;
            _config["proxyHost"] = Settings.Default.proxyHost;
            _config["merchantId"] = Settings.Default.merchantId;
            _config["password"] = Settings.Default.password;
            _config["proxyPort"] = Settings.Default.proxyPort;
            _config["sftpUrl"] = Settings.Default.sftpUrl;
            _config["sftpUsername"] = Settings.Default.sftpUsername;
            _config["sftpPassword"] = Settings.Default.sftpPassword;
            _config["knownHostsFile"] = Settings.Default.knownHostsFile;
            _config["requestDirectory"] = Settings.Default.requestDirectory;
            _config["responseDirectory"] = Settings.Default.responseDirectory;

            _litleTime = new LitleTime();
            _litleFile = new LitleFile();

            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";
        }

        public RfrRequest(Dictionary<String, String> config)
        {
            _config = config;
            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";

            _litleFile = new LitleFile();
            _litleTime = new LitleTime();
        }

        public string GetRequestDirectory()
        {
            return _requestDirectory;
        }

        public string GetResponseDirectory()
        {
            return _responseDirectory;
        }

        public void SetConfig(Dictionary<String, String> config)
        {
            _config = config;
        }

        public void SetLitleFile(LitleFile litleFile)
        {
            _litleFile = litleFile;
        }

        public LitleFile GetLitleFile()
        {
            return _litleFile;
        }

        public void SetLitleTime(LitleTime litleTime)
        {
            _litleTime = litleTime;
        }

        public LitleTime GetLitleTime()
        {
            return _litleTime;
        }

        public string Serialize()
        {
            const string xmlHeader = "\r\n<RFRRequest xmlns=\"http://www.litle.com/schema\">";
            const string xmlFooter = "\r\n</RFRRequest>";

            string filePath = _litleFile.CreateRandomFile(_requestDirectory, null, "_RFRRequest.xml", _litleTime);

            string xmlBody = "";

            if (AccountUpdateFileRequestData != null)
            {
                xmlBody += "\r\n<accountUpdateFileRequestData>";
                xmlBody += AccountUpdateFileRequestData.Serialize();
                xmlBody += "\r\n</accountUpdateFileRequestData>";
            }
            else
            {
                xmlBody += "\r\n<litleSessionId>" + LitleSessionId + "</litleSessionId>";
            }
            _litleFile.AppendLineToFile(filePath, xmlHeader);
            _litleFile.AppendLineToFile(filePath, xmlBody);
            _litleFile.AppendLineToFile(filePath, xmlFooter);

            return filePath;
        }
    }

    public class EcheckPreNoteCredit : transactionTypeWithReportGroup
    {
        /// <remarks />
        public string OrderId { get; set; }

        /// <remarks />
        public orderSourceType OrderSource { get; set; }

        /// <remarks />
        public contact BillToAddress { get; set; }

        /// <remarks />
        public echeckType Echeck { get; set; }

        /// <remarks />
        public merchantDataType MerchantData { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<echeckPreNoteCredit ";

            if (id != null)
            {
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            }
            if (customerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";

            if (OrderSource != null)
            {
                xml += "\r\n<orderSource>";
                xml += OrderSource.Serialize();
                xml += "</orderSource>";
            }

            if (BillToAddress != null)
            {
                xml += "\r\n<billToAddress>";
                xml += BillToAddress.Serialize();
                xml += "\r\n</billToAddress>";
            }

            if (Echeck != null)
            {
                xml += "\r\n<echeck>";
                xml += Echeck.Serialize();
                xml += "\r\n</echeck>";
            }

            if (MerchantData != null)
            {
                xml += "\r\n<merchantData>";
                xml += MerchantData.Serialize();
                xml += "\r\n</merchantData>";
            }

            xml += "\r\n</echeckPreNoteCredit>";

            return xml;
        }
    }

    public class EcheckPreNoteSale : transactionTypeWithReportGroup
    {
        /// <remarks />
        public string OrderId { get; set; }

        /// <remarks />
        public orderSourceType OrderSource { get; set; }

        /// <remarks />
        public contact BillToAddress { get; set; }

        /// <remarks />
        public echeckType Echeck { get; set; }

        /// <remarks />
        public merchantDataType MerchantData { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<echeckPreNoteSale ";

            if (id != null)
            {
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            }
            if (customerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";

            if (OrderSource != null)
            {
                xml += "\r\n<orderSource>";
                xml += OrderSource.Serialize();
                xml += "</orderSource>";
            }

            if (BillToAddress != null)
            {
                xml += "\r\n<billToAddress>";
                xml += BillToAddress.Serialize();
                xml += "\r\n</billToAddress>";
            }

            if (Echeck != null)
            {
                xml += "\r\n<echeck>";
                xml += Echeck.Serialize();
                xml += "\r\n</echeck>";
            }

            if (MerchantData != null)
            {
                xml += "\r\n<merchantData>";
                xml += MerchantData.Serialize();
                xml += "\r\n</merchantData>";
            }

            xml += "\r\n</echeckPreNoteSale>";

            return xml;
        }
    }

    public class SubmerchantCredit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string SubmerchantName { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public echeckType AccountInfo { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<submerchantCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (SubmerchantName != null)
                xml += "\r\n<submerchantName>" + SecurityElement.Escape(SubmerchantName) + "</submerchantName>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            if (AccountInfo != null)
            {
                xml += "\r\n<accountInfo>";
                xml += AccountInfo.Serialize();
                xml += "</accountInfo>";
            }

            xml += "\r\n</submerchantCredit>";

            return xml;
        }
    }

    public class PayFacCredit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<payFacCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            xml += "\r\n</payFacCredit>";

            return xml;
        }
    }

    public class ReserveCredit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<reserveCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            xml += "\r\n</reserveCredit>";

            return xml;
        }
    }

    public class VendorCredit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string VendorName { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public echeckType AccountInfo { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<vendorCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (VendorName != null)
                xml += "\r\n<vendorName>" + SecurityElement.Escape(VendorName) + "</vendorName>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            if (AccountInfo != null)
            {
                xml += "\r\n<accountInfo>";
                xml += AccountInfo.Serialize();
                xml += "</accountInfo>";
            }

            xml += "\r\n</vendorCredit>";

            return xml;
        }
    }

    public class PhysicalCheckCredit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<physicalCheckCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            xml += "\r\n</physicalCheckCredit>";

            return xml;
        }
    }

    public class SubmerchantDebit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string SubmerchantName { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public echeckType AccountInfo { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<submerchantDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (SubmerchantName != null)
                xml += "\r\n<submerchantName>" + SecurityElement.Escape(SubmerchantName) + "</submerchantName>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            if (AccountInfo != null)
            {
                xml += "\r\n<accountInfo>";
                xml += AccountInfo.Serialize();
                xml += "</accountInfo>";
            }

            xml += "\r\n</submerchantDebit>";

            return xml;
        }
    }

    public class PayFacDebit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<payFacDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            xml += "\r\n</payFacDebit>";

            return xml;
        }
    }

    public class ReserveDebit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<reserveDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            xml += "\r\n</reserveDebit>";

            return xml;
        }
    }

    public class VendorDebit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string VendorName { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public echeckType AccountInfo { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<vendorDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (VendorName != null)
                xml += "\r\n<vendorName>" + SecurityElement.Escape(VendorName) + "</vendorName>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            if (AccountInfo != null)
            {
                xml += "\r\n<accountInfo>";
                xml += AccountInfo.Serialize();
                xml += "</accountInfo>";
            }

            xml += "\r\n</vendorDebit>";

            return xml;
        }
    }

    public class PhysicalCheckDebit : transactionTypeWithReportGroup
    {
        public string FundingSubmerchantId { get; set; }

        public string FundsTransferId { get; set; }

        public long? Amount { get; set; }

        public override string Serialize()
        {
            string xml = "\r\n<physicalCheckDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (FundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(FundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (FundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(FundsTransferId) + "</fundsTransferId>";
            if (Amount != null)
                xml += "\r\n<amount>" + Amount + "</amount>";

            xml += "\r\n</physicalCheckDebit>";

            return xml;
        }
    }
}