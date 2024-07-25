namespace Cleanup
{
    internal class Program
    {
        private const double TargetChangeTime = 1;

        private double _previousTargetSetTime;
        private object _target;
        private object _previousTarget;
        private object _activeTarget;
        private object _targetInRangeContainer;

        public void CleanupTest(Frame frame)
        {
            TryChangeTarget();
            
            TryUpdatePreviousTargetSetTime();

            TargetableEntity.Selected = _target;
        }

        private void TryChangeTarget()
        {
            TrySetActiveTargetFromQuantum(frame);

            if (!IsNeedChangeTarget())
            {
                return;
            }

            _previousTarget = _target;


            if (_activeTarget && _activeTarget.CanBeTarget)
            {
                _target = _activeTarget;
                return;
            }

            //не уверен насчёт _targetInRangeContainer. Вроде нигде не сеттиться исходя из этого кода, но на всякий случай оставлю.
            //в проекте посмотрел бы по IDE. Если нигде не сеттится, то поменял бы строку на _target = null; и удалил бы поле _targetInRangeContainer
            _target = _targetInRangeContainer.GetTarget();
        }

        private bool IsNeedChangeTarget()
        {
            if (_target && _target.CanBeTarget && Time.time - _previousTargetSetTime < TargetChangeTime)
            {
                return false;
            }

            return true;
        }

        private void TryUpdatePreviousTargetSetTime()
        {
            if (!_target) {return;}
            if(_previousTarget == _target){return;}
            _previousTargetSetTime = Time.time;
        }
    }
}
