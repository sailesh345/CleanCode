
## **1. What Are Side Effects?**  
A **side effect** occurs when a function:  
✅ Modifies **external state** (e.g., changing a global variable, mutating an input object).  
✅ Performs **I/O operations** (e.g., writing to a file, making an HTTP request).  
✅ Throws **unexpected exceptions**.  

### **Pure vs. Impure Functions**  
| **Pure Function** | **Impure Function** |  
|------------------|-------------------|  
| No side effects | Has side effects |  
| Same input → Same output | Output may vary |  
| Easier to test/debug | Harder to test |  

---

## **2. Common Side Effects (With Examples)**  

### **🛑 1. Modifying External State (C# & Python)**  
**C# Example (Impure):**  
```csharp  
private int _counter = 0;  

public int IncrementCounter()  
{  
    _counter++; // Side effect: Modifies global state  
    return _counter;  
}  
```  
**Python Example (Impure):**  
```python  
counter = 0  

def increment_counter():  
    global counter  
    counter += 1  # Side effect  
    return counter  
```  

**Fix:** Return a new value instead of mutating state.  

---

### **🛑 2. Mutating Input Arguments (C# & Python)**  
**C# Example (Impure):**  
```csharp  
public void ApplyDiscount(Order order, decimal discount)  
{  
    order.Total *= (1 - discount); // Side effect: Changes input object  
}  
```  
**Python Example (Impure):**  
```python  
def apply_discount(order, discount):  
    order["total"] *= (1 - discount)  # Mutates input  
```  

**Fix:** Return a **new object** instead.  
```csharp  
public Order ApplyDiscount(Order order, decimal discount)  
{  
    return new Order { Total = order.Total * (1 - discount) };  
}  
```  

---

### **🛑 3. I/O Operations (C# & Python)**  
**C# Example (Impure):**  
```csharp  
public void LogError(string message)  
{  
    File.AppendAllText("errors.log", message); // Side effect: File I/O  
}  
```  
**Python Example (Impure):**  
```python  
def log_error(message):  
    with open("errors.log", "a") as f:  
        f.write(message)  # Side effect  
```  

**Fix:**  
- Separate **business logic** from I/O.  
- Use **dependency injection** for testability.  

---

### **🛑 4. Unpredictable Behavior (C# & Python)**  
**C# Example (Impure due to DateTime.Now):**  
```csharp  
public string GetGreeting()  
{  
    return DateTime.Now.Hour < 12 ? "Good morning" : "Hello"; // Depends on external state  
}  
```  
**Python Example (Impure due to random):**  
```python  
import random  

def roll_dice():  
    return random.randint(1, 6)  # Non-deterministic  
```  

**Fix:** Pass dependencies explicitly.  
```csharp  
public string GetGreeting(DateTime currentTime)  
{  
    return currentTime.Hour < 12 ? "Good morning" : "Hello";  
}  
```  

---

## **3. Best Practices to Reduce Side Effects**  
✔ **Prefer pure functions** where possible.  
✔ **Isolate side effects** (e.g., keep I/O at the app’s edges).  
✔ **Use immutable data structures** (e.g., `readonly` in C#, `tuple` in Python).  
✔ **Avoid global state** (dependency injection helps).  
✔ **Document side effects** in method signatures (e.g., `void UpdateDatabase()` clearly implies mutation).  

---

### **When Are Side Effects Acceptable?**  
- **At system boundaries** (e.g., saving to a DB, sending emails).  
- **Performance-critical code** (but document carefully).  
