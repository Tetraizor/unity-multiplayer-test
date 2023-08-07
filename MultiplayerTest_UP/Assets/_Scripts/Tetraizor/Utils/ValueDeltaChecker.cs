using UnityEngine.Events;

namespace Tetraizor.Utils
{
    public class ValueDeltaChecker<T>
    {
        private readonly UnityEvent<T, T> _valueChangeEvent = new UnityEvent<T, T>();
        private T _currentValue, _lastValue;

        public void BindOnValueChangeEvent(UnityAction<T, T> methodToBind)
        {
            _valueChangeEvent?.AddListener(methodToBind);
        }

        public void UnbindOnValueChangeEvent(UnityAction<T,T> methodToBind)
        {
            _valueChangeEvent?.RemoveListener(methodToBind);
        }

        public void UnbindAllOnValueChangeEvents(UnityAction<T, T> methodToBind)
        {
            _valueChangeEvent?.RemoveAllListeners();
        }

        public void Initialize(T initialValue)
        {
            _currentValue = initialValue;
            _lastValue = initialValue;

            _valueChangeEvent?.Invoke(_currentValue, _lastValue);
        }

        public bool UpdateValue(T value)
        {
            bool hasChanged = false;

            _currentValue = value;

            if (!_currentValue.Equals(_lastValue))
            {
                _valueChangeEvent?.Invoke(_currentValue, _lastValue);
                hasChanged = true;
            }

            _lastValue = _currentValue;

            return hasChanged;
        }
    }
}
