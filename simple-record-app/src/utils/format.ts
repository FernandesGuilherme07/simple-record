export function formatPhoneNumber(phoneNumber: string): string {
    // Remove todos os caracteres não numéricos do número de telefone
    const cleanedPhoneNumber = phoneNumber.replace(/\D/g, '');
  
    // Verifica se o número de telefone tem o formato correto
    if (cleanedPhoneNumber.length === 11) {
      // Formato para números de celular: (99) 9 9999-9999
      const areaCode = cleanedPhoneNumber.substring(0, 2);
      const firstPart = cleanedPhoneNumber.substring(2, 7);
      const secondPart = cleanedPhoneNumber.substring(7, 11);
      return `(${areaCode}) 9 ${firstPart}-${secondPart}`;
    } else {
      // Formato para outros números: (99) 9999-9999
      const areaCode = cleanedPhoneNumber.substring(0, 2);
      const firstPart = cleanedPhoneNumber.substring(2, 6);
      const secondPart = cleanedPhoneNumber.substring(6, 10);
      return `(${areaCode}) ${firstPart}-${secondPart}`;
    }
  }
  
  export function formatCPF(cpf: string): string {
    // Remove todos os caracteres não numéricos do CPF
    const cleanedCPF = cpf.replace(/\D/g, '');
  
    // Formato: 999.999.999-99
    const firstPart = cleanedCPF.substring(0, 3);
    const secondPart = cleanedCPF.substring(3, 6);
    const thirdPart = cleanedCPF.substring(6, 9);
    const fourthPart = cleanedCPF.substring(9, 11);
    return `${firstPart}.${secondPart}.${thirdPart}-${fourthPart}`;
  }
  
  export function formatCNPJ(cnpj: string): string {
    // Remove todos os caracteres não numéricos do CNPJ
    const cleanedCNPJ = cnpj.replace(/\D/g, '');
  
    // Formato: 99.999.999/9999-99
    const firstPart = cleanedCNPJ.substring(0, 2);
    const secondPart = cleanedCNPJ.substring(2, 5);
    const thirdPart = cleanedCNPJ.substring(5, 8);
    const fourthPart = cleanedCNPJ.substring(8, 12);
    const fifthPart = cleanedCNPJ.substring(12, 14);
    return `${firstPart}.${secondPart}.${thirdPart}/${fourthPart}-${fifthPart}`;
  }
  
  // Função para aplicar a máscara de CPF/CNPJ
  export const formatDocument = (type:  0 | 1, value: string): string => {
    const isPhysical = type === 0;
    const regex = isPhysical ? /(\d{3})(\d{3})(\d{3})(\d{2})/ : /(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/;
    const onlyNumbers = value.replace(/\D/g, '').slice(0, isPhysical ? 11 : 14); // Limita o número de dígitos
    return onlyNumbers.replace(regex, isPhysical ? '$1.$2.$3-$4' : '$1.$2.$3/$4-$5');
  };

  export const formatCEP = (cep: string) => {
    // Remove qualquer caractere que não seja número
    const numericCep = cep.replace(/\D/g, '');

    // Limita o CEP a 8 caracteres
    const formattedCep = numericCep.slice(0, 8);

    // Aplica a máscara de CEP: 99999-999
    const maskedCep = formattedCep.replace(/(\d{5})(\d{3})/, '$1-$2');

    return maskedCep;
  };

  // Função para aplicar a máscara de telefone
  export const formatPhone = (value: string): string => {
    const regex = /(\d{2})(\d{1})(\d{4})(\d{4})/;
    const onlyNumbers = value.replace(/\D/g, '').slice(0, 11); // Limita o número de dígitos
    return onlyNumbers.replace(regex, '($1) $2 $3-$4');
  };