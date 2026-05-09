using UnityEngine;
using UnityEngine.InputSystem;

public class Raquete : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;

    [SerializeField] private float speed = 10f; //Velocidade Raquete
    [SerializeField] private float limity = 3.66f;//Limiti raquete no eixo Y

    private float myY;//Y da raquete 

    private void OnEnable()
    {
        moveAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Start()
    {
        myY = transform.position.y;//pegar posição Y
    }

    private void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        myY += input.y * speed * Time.deltaTime;//Ganho
        myY = Mathf.Clamp(myY, -limity, limity);//Limite

        //movimentação 
        Vector3 pos = transform.position;// pega posição atual 
        pos.y = myY;//atribui a nova posição 
        transform.position = pos;//Move a raquete 


    }
}
