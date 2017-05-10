using Microsoft.Extensions.Logging;

namespace LogWeb5
{
    public class SomethingSvc : ISomethingSvc
    {
        private readonly IOtherSvc _otherSvc;
        private readonly ILogger<SomethingSvc> _logger;

        public SomethingSvc(IOtherSvc otherSvc, ILogger<SomethingSvc> logger)
        {
            _otherSvc = otherSvc;
            _logger = logger;
        }

        public void SideEffects()
        {
            _logger.LogDebug("No side effects!");
        }

        public void DoSomething()
        {
            _logger.LogTrace("Begin DoSomething");

            using (_logger.BeginScope("Do"))
            {
                SideEffects();

                _otherSvc.DoOther();
            }

            _logger.LogTrace("End DoSomething");
        }
    }
}